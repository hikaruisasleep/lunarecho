using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public TMP_Text nameUI;
        public TMP_Text dialogueUI;

        public Animator animator;

        public float typingSpeed;

        public Queue<string> sentences;

        [field: SerializeField] public bool IsInDialogue { get; private set; }

        [SerializeField] private bool txtRunning;

        void Start()
        {
            sentences = new Queue<string>();
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

        private void Update()
        {
            InputActionMap actionMap_game = InputSystem.actions.FindActionMap("Game");
            InputAction mbl = actionMap_game.FindAction("Left Click");
            InputAction interact = actionMap_game.FindAction("Interact");

            if (IsInDialogue && (mbl.WasPressedThisFrame() || interact.WasPressedThisFrame()))
            {
                DisplayNextSentence();
            }
        }

        public void StartDialogue(Dialogue dialogue)
        {
            IsInDialogue = true;
            animator.SetBool("isOpen", IsInDialogue);

            Time.timeScale = 0;

            nameUI.text = dialogue.name;
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
        }

        private void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();

            if (!txtRunning)
            {
                StopAllCoroutines();
                StartCoroutine(TextTyping(sentence));
            }
        }

        IEnumerator TextTyping(string sentence)
        {
            txtRunning = true;
            dialogueUI.text = "";
            foreach (char letter in sentence)
            {
                dialogueUI.text += letter;
                yield return new WaitForSecondsRealtime(typingSpeed / 1000);
            }
            txtRunning = false;
        }

        void EndDialogue()
        {
            IsInDialogue = false;
            txtRunning = false;
            StopAllCoroutines();
            Time.timeScale = 1;
            animator.SetBool("isOpen", IsInDialogue);
        }
    }
}