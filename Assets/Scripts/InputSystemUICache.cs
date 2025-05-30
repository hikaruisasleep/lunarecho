using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputSystemUICache : MonoBehaviour
{
    [SerializeField]
    private InputActionReference navigate;

    private void OnEnable()
    {
        navigate.action.performed += OnPerformed;
    }

    private void OnDisable()
    {
        navigate.action.performed -= OnPerformed;
    }

    void OnPerformed(InputAction.CallbackContext ctx)
    {
        if (EventSystem.current.currentSelectedGameObject == null || !EventSystem.current.currentSelectedGameObject.activeInHierarchy || !EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().IsInteractable())
        {
            foreach (Selectable selectable in FindObjectsByType<Selectable>(FindObjectsSortMode.None))
            {
                if (selectable.IsInteractable() && selectable.isActiveAndEnabled)
                {
                    EventSystem.current.SetSelectedGameObject(selectable.gameObject);
                }
            }
        }
    }
}
