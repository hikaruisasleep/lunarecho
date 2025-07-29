using TMPro;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.EventSystems;
=======
>>>>>>> 39a5b7f (lol)
using UnityEngine.InputSystem;

namespace PlayerVitalsSystem
{
<<<<<<< HEAD
    public class TemporaryOxygenRechargeSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
=======
    public class TemporaryOxygenRechargeSystem : MonoBehaviour
    {
        [SerializeField] private bool near;
>>>>>>> 39a5b7f (lol)
        [SerializeField] private bool isInteractible;

        InputActionMap actionMap_game;
        InputAction interact;

        public GameObject interactivePromptsGroup;

        public VitalsManager manager;
<<<<<<< HEAD

        private void Start()
        {
            actionMap_game = InputSystem.actions.FindActionMap("Game");
            interact = actionMap_game.FindAction("Interact");
=======
        private Transform player;
        private Transform xf;

        private void Awake()
        {
            actionMap_game = InputSystem.actions.FindActionMap("Game");
            interact = actionMap_game.FindAction("Interact");

            xf = GetComponent<Transform>();
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
>>>>>>> 39a5b7f (lol)
        }

        private void Update()
        {
<<<<<<< HEAD
            if (isInteractible && interact.WasPressedThisFrame())
=======
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
>>>>>>> 39a5b7f (lol)
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
<<<<<<< HEAD
            if (collider.CompareTag("Player"))
=======
            if (collider.CompareTag("Player") && near)
>>>>>>> 39a5b7f (lol)
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

<<<<<<< HEAD
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

=======
>>>>>>> 39a5b7f (lol)
        private void EnterEvent()
        {
            isInteractible = true;
            LeanTween.moveLocal(interactivePromptsGroup, new Vector3(0f, 0.75f), 0.75f).setEaseInOutSine().setLoopOnce();
            LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 0), new Color32(255, 255, 255, 255), 1f).setEaseInCubic().setLoopOnce();
<<<<<<< HEAD
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Mining);
=======
>>>>>>> 39a5b7f (lol)
        }

        private void ExitEvent()
        {
            isInteractible = false;
            LeanTween.moveLocal(interactivePromptsGroup, Vector3.zero, 0.75f).setEaseInOutSine().setLoopOnce();
            LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0), 1f).setEaseOutCubic().setLoopOnce();
<<<<<<< HEAD
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Default);
=======
>>>>>>> 39a5b7f (lol)
        }
    }
}