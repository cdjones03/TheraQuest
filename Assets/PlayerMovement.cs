using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float wallJumpForce = 12f; // Force for wall jumping
    [SerializeField] private float wallSlideSpeed = 2f; // Speed when sliding down walls
    [SerializeField] private float tolerance = .1f; // Tolerance for position checks
    
    private Rigidbody2D rb;
    public bool isGrounded;
    public bool isTouchingWall;
    public bool isWallSliding;
    public int wallDirection; // 1 for right wall, -1 for left wall
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private bool IsOnTopOfWall()
    {
        // Check if we're touching a wall and our y velocity is approximately 0 (standing)
        if (isTouchingWall && Mathf.Abs(rb.linearVelocity.y) < tolerance)
        {
            
            // Check slightly below the player's position
            Vector2 checkPosition = transform.position + Vector3.down * 0.5f;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(checkPosition, tolerance);
            
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Wall"))
                {
                    // Check if we're above the wall by comparing y positions
                    float playerBottom = transform.position.y - GetComponent<Collider2D>().bounds.extents.y;
                    float wallTop = collider.bounds.max.y;
                    
                    bool isOnTop = Mathf.Abs(playerBottom - wallTop) < tolerance;
                    return isOnTop;
                }
            }
        }
        return false;
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        
        // Check if player has zero vertical velocity (standing still)
        if (Mathf.Abs(rb.linearVelocity.y) < tolerance)
        {
            isGrounded = true;
        }
        
        // Handle wall sliding
        if (isTouchingWall && !isGrounded && moveInput * wallDirection > 0)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(0f, Mathf.Max(rb.linearVelocity.y, -wallSlideSpeed));
        }
        else
        {
            isWallSliding = false;
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
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
