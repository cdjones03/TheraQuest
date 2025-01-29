using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private float startingX; // Store initial X position
    [SerializeField] private float smoothSpeed = 5f; // Adjust in inspector to control smoothness
    private const float MIN_X = -157f;
    private const float MAX_X = 157f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the player by looking for the PlayerMovement component
        player = GameObject.FindObjectOfType<PlayerMovement>().transform;
        
        // Store the camera's initial X position
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Create target position with clamped X and player's Y
            float clampedX = Mathf.Clamp(player.position.x, MIN_X, MAX_X);
            Vector3 targetPosition = new Vector3(clampedX, player.position.y, transform.position.z);
            
            // Smoothly interpolate between current position and target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
