using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public float loadingProgress;

    Pointer surface;
    Mouse mouse;

    [SerializeField] InputActionReference point;

    public void StartGame()
    {
        StartCoroutine(LoadSceneAsync("SampleScene"));
    }

    IEnumerator LoadSceneAsync(string scene)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scene);

        while (!sceneLoading.isDone)
        {
            loadingProgress = Mathf.Clamp01(sceneLoading.progress / 0.9f);
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        surface = Pointer.current;
        mouse = Mouse.current;
    }

    private void Update()
    {
        Debug.Log(point.action.ReadValue<Vector2>());
    }
}
