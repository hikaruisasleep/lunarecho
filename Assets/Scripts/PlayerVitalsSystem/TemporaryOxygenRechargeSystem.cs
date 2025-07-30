using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerVitalsSystem
{
    public class TemporaryOxygenRechargeSystem : MonoBehaviour
    {
        [SerializeField] private bool near;
        [SerializeField] private bool isInteractible;

        InputActionMap actionMap_game;
        InputAction interact;

        public GameObject interactivePromptsGroup;

        public VitalsManager manager;
        private Transform player;
        private Transform xf;

        private void Awake()
        {
            actionMap_game = InputSystem.actions.FindActionMap("Game");
            interact = actionMap_game.FindAction("Interact");

            xf = GetComponent<Transform>();
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            float distance = Vector3.Distance(xf.position, player.position);

            if (distance < 1.5f)
            {
                near = true;
            }
            else
            {
                near = false;
            }

            if (isInteractible && near && interact.WasPressedThisFrame())
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
            if (collider.CompareTag("Player") && near)
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

        private void EnterEvent()
        {
            isInteractible = true;
            LeanTween.moveLocal(interactivePromptsGroup, new Vector3(0f, 0.75f), 0.75f).setEaseInOutSine().setLoopOnce();
            LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 0), new Color32(255, 255, 255, 255), 1f).setEaseInCubic().setLoopOnce();
        }

        private void ExitEvent()
        {
            isInteractible = false;
            LeanTween.moveLocal(interactivePromptsGroup, Vector3.zero, 0.75f).setEaseInOutSine().setLoopOnce();
            LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0), 1f).setEaseOutCubic().setLoopOnce();
        }
    }
}