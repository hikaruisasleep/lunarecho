using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace DialogueSystem
{
    public class NPCDialogueTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private bool playerIsClose;
        private InputAction interact;

        public Dialogue dialogue;

        public DialogueManager manager;

        public GameObject interactivePromptsGroup;

        private void Start()
        {
            interact = InputSystem.actions.FindAction("Interact");
            manager = FindAnyObjectByType<DialogueManager>();
        }

        public void TriggerDialogue()
        {
            manager.StartDialogue(dialogue);
        }

        private void Update()
        {
            if (playerIsClose && !manager.IsInDialogue && interact.WasPressedThisFrame())
            {
                manager.StartDialogue(dialogue);
            }
        }

        private void UpdateTextTransparency(Color value)
        {
            interactivePromptsGroup.GetComponentInChildren<TMP_Text>().color = value;
            interactivePromptsGroup.GetComponentInChildren<SpriteRenderer>().color = value;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!playerIsClose)
            {
                if (collider.CompareTag("Player"))
                {
                    playerIsClose = true;
                    LeanTween.moveLocal(interactivePromptsGroup, new Vector3(0f, 1f), 0.75f).setEaseInOutSine().setLoopOnce();
                    LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 0), new Color32(255, 255, 255, 255), 1f).setEaseInCubic().setLoopOnce();
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collider)
        {
            if (playerIsClose)
            {
                if (collider.CompareTag("Player"))
                {
                    playerIsClose = false;
                    LeanTween.moveLocal(interactivePromptsGroup, Vector3.zero, 0.75f).setEaseInOutSine().setLoopOnce();
                    LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0), 1f).setEaseOutCubic().setLoopOnce();
                }
            }
        }

        public void OnPointerEnter(PointerEventData e)
        {
            if (!playerIsClose)
            {
                playerIsClose = true;
                LeanTween.moveLocal(interactivePromptsGroup, new Vector3(0f, 1f), 0.75f).setEaseInOutSine().setLoopOnce();
                LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 0), new Color32(255, 255, 255, 255), 1f).setEaseInCubic().setLoopOnce();
            }
        }

        public void OnPointerExit(PointerEventData e)
        {
            if (playerIsClose)
            {
                playerIsClose = false;
                LeanTween.moveLocal(interactivePromptsGroup, Vector3.zero, 0.75f).setEaseInOutSine().setLoopOnce();
                LeanTween.value(interactivePromptsGroup, UpdateTextTransparency, new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0), 1f).setEaseOutCubic().setLoopOnce();
            }
        }
    }
}