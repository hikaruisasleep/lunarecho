using UnityEngine;
using UnityEngine.InputSystem;

public class SSPlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    // Movement
    public float moveSpeed = 6f;
    float horizontalMovement;

    // Jump
    public float jumpPower = 10f;

    // Ground Checker
    public Transform GroundCheckerPosition;
    public Vector2 GroundCheckerSize = new Vector2(0.5f, 0.05f);
    public LayerMask GroundLayer;

    // Gravity
    public float baseGravity = 2;
    public float maxFallSpeed = 10f;
    public float fallSpeedMultiplier = 1.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
        Gravity();
    }

    private void Gravity()
    {
        if(rb.linearVelocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
        }

        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    // Move Funtion
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        horizontalMovement = input.x;
    }

    // Jump Function
    public void Jump(InputAction.CallbackContext context)
    {
        if (isOnGround())
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            }
            else if (context.canceled)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0f);
            }
        }
    }

    // Ground Checker
    private bool isOnGround()
    {
        if (Physics2D.OverlapBox(GroundCheckerPosition.position, GroundCheckerSize, 0, GroundLayer))
        {
            return true;
        }
        return false;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(GroundCheckerPosition.position, GroundCheckerSize);
    }
}
