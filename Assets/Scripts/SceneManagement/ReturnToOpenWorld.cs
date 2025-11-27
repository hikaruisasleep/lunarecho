using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReturnToOpenWorld : MonoBehaviour
{
    public float loadingProgress;
    public bool isTouching;

    void Update()
    {
        if (isTouching && InputSystem.actions.FindActionMap("Game").FindAction("Move").ReadValue<Vector2>().y < -0.1)
        {
            LoadOpenWorld();
        }
    }

    public void LoadOpenWorld()
    {
        SceneMemory.outdoor = true;
        StartCoroutine(LoadSceneAsync("SampleScene"));
    }

    IEnumerator LoadSceneAsync(string scene)
    {
        SceneMemory.outdoor = true;
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scene);

        while (!sceneLoading.isDone)
        {
            loadingProgress = Mathf.Clamp01(sceneLoading.progress / 0.9f);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!isTouching)
            {
                if (collider.CompareTag("Player"))
                {
                    isTouching = true;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (isTouching)
            {
                if (collider.CompareTag("Player"))
                {
                    isTouching = false;
                }
            }
        }
}
