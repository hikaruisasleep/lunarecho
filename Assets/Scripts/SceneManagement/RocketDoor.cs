using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RocketDoor : MonoBehaviour
{
    public float loadingProgress;
    public bool isTouching;

    void Update()
    {
        if (isTouching && InputSystem.actions.FindActionMap("Game").FindAction("Move").ReadValue<Vector2>().y > 0.1)
        {
            LoadRocketScene();
        }
    }

    public void LoadRocketScene()
    {
        StartCoroutine(LoadSceneAsync("Indoor"));
    }

    IEnumerator LoadSceneAsync(string scene)
    {
        SceneMemory.outdoor = false;
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
                    SceneMemory.lastOutdoorPosition = collider.transform.position;
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
