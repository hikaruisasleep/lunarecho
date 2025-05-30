using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputActionMap actionMap_game;
    InputAction moveInput;

    [SerializeField] protected Rigidbody2D rigidBody;
    [SerializeField] private float velocity = 5.0f;
    Vector2 moveValue;

    Animator animator;
    private Vector2 lastMoveDir;
    private bool facing = true;

    private void Start()
    {
        actionMap_game = InputSystem.actions.FindActionMap("Game");
        moveInput = actionMap_game.FindAction("Move");

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovementInputs();
        Animate();
    }

    void FixedUpdate()
    {
        Move(moveValue);
    }

    void Move(Vector3 dir)
    {
        rigidBody.linearVelocity = dir * velocity;
    }

    void MovementInputs()
    {
        float moveX = moveInput.ReadValue<Vector2>().x;
        float moveY = moveInput.ReadValue<Vector2>().y;

        if ((moveX == 0 && moveY == 0) && (moveValue.x != 0 || moveValue.y != 0))
        {
            lastMoveDir = moveValue;
        }

        moveValue = moveInput.ReadValue<Vector2>();
        moveValue.Normalize();
    }

    void Animate()
    {
        animator.SetFloat("MoveX", moveValue.x);
        animator.SetFloat("MoveY", moveValue.y);
        animator.SetFloat("MoveMagnitude", moveValue.sqrMagnitude);
        animator.SetFloat("LastMoveX", lastMoveDir.x);
        animator.SetFloat("LastMoveY", lastMoveDir.y);
    }
}
