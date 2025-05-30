using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace PlayerVitalsSystem
{
    public class TemporaryOxygenRechargeSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        [SerializeField] private bool isInteractible;

        InputActionMap actionMap_game;
        InputAction interact;

        public GameObject interactivePromptsGroup;

        public VitalsManager manager;

        private void Start()
        {
            actionMap_game = InputSystem.actions.FindActionMap("Game");
            interact = actionMap_game.FindAction("Interact");
        }

        private void Update()
        {
            if (isInteractible && interact.WasPressedThisFrame())
            {
                manager.ReplenishOxygen();
            }
        }

        private void UpdateTextTransparency(Color value)
        {
            interactivePromptsGroup.GetComponentInChildren<TMP_Text>().color = value;
            interactivePromptsGroup.GetComponentInChildren<SpriteRenderer>().color = value;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                EnterEvent();
            }
        }
        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                ExitEvent();
            }
        }

        public void OnPointerEnter(PointerEventData e)
        {
            EnterEvent();
        }

        public void OnPointerExit(PointerEventData e)
        {
            ExitEvent();
        }

        public void OnPointerDown(PointerEventData e)
        {
            manager.ReplenishOxygen();
        }

        private void EnterEvent()
        {
            isInteractible = true;
            LeanTween.moveLocal(interactivePromptsGroup, new Vector3(0f, 0.75f), 0.75f).setEaseInOutSine().setLoopOnce();
            LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 0), new Color32(255, 255, 255, 255), 1f).setEaseInCubic().setLoopOnce();
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Mining);
        }

        private void ExitEvent()
        {
            isInteractible = false;
            LeanTween.moveLocal(interactivePromptsGroup, Vector3.zero, 0.75f).setEaseInOutSine().setLoopOnce();
            LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0), 1f).setEaseOutCubic().setLoopOnce();
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Default);
        }
    }
}