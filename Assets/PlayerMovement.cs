using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float wallJumpForce = 12f; // Force for wall jumping
    [SerializeField] private float wallSlideSpeed = 2f; // Speed when sliding down walls
    
    private Rigidbody2D rb;
    public bool isGrounded;
    public bool isTouchingWall;
    public bool isWallSliding;
    public int wallDirection; // 1 for right wall, -1 for left wall
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        
        // Handle wall sliding
        if (isTouchingWall && !isGrounded && moveInput * wallDirection > 0)
        {
            isWallSliding = true;
            Debug.Log($"Wall Sliding: Direction={wallDirection}, MoveInput={moveInput}");
            rb.linearVelocity = new Vector2(0f, Mathf.Max(rb.linearVelocity.y, -wallSlideSpeed));
        }
        else
        {
            isWallSliding = false;
            // Only apply normal movement when not wall sliding
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }

        // Handle jumping (both ground and wall)
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log($"Jump pressed - IsGrounded: {isGrounded}, IsWallSliding: {isWallSliding}, IsTouchingWall: {isTouchingWall}");
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
            else if (isWallSliding)
            {
                Debug.Log("Attempting wall jump!");
                // Wall jump: Push up and away from wall
                Vector2 wallJumpDirection = new Vector2(-wallDirection, 1).normalized;
                rb.linearVelocity = Vector2.zero; // Reset velocity for consistent wall jumps
                rb.AddForce(wallJumpDirection * wallJumpForce, ForceMode2D.Impulse);
                isWallSliding = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        // Check for wall collision
        CheckWallCollision(collision);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Continuously check for wall collision
        CheckWallCollision(collision);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        
        // Reset wall variables when leaving a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = false;
            isWallSliding = false;
        }
    }

    private void CheckWallCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = true;
            
            // Determine which side the wall is on
            Vector2 contactNormal = collision.GetContact(0).normal;
            wallDirection = Mathf.RoundToInt(-contactNormal.x); // -1 for right wall, 1 for left wall
        }
    }
}
