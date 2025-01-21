using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(TMP_InputField))]
public class DynamicTextCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private TMP_InputField inputField;
    
    [SerializeField] private float horizontalPadding = 10f; // Extra space on sides
    [SerializeField] private float leftOffset = 0f; // Distance from left edge to start the collider
    [SerializeField] private float fixedHeight = 50f; // Fixed height for the collider

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        inputField = GetComponent<TMP_InputField>();

        // Set up listener for text changes
        inputField.onValueChanged.AddListener((_) => UpdateColliderSize());
        
        // Initial size update
        UpdateColliderSize();
    }

    private void UpdateColliderSize()
    {
        if (boxCollider == null || inputField == null) return;

        // Get the preferred width of the text
        float textWidth = inputField.textComponent.GetPreferredValues().x;
        
        // Add padding to width only
        textWidth += horizontalPadding;

        // Update the collider size (keeping height fixed)
        boxCollider.size = new Vector2(textWidth, fixedHeight);
        
        // Set offset to anchor on the left (keeping vertical offset unchanged)
        boxCollider.offset = new Vector2(leftOffset + (textWidth / 2f), boxCollider.offset.y);
    }

    private void OnValidate()
    {
        // Update in editor when component is modified
        if (Application.isPlaying)
        {
            UpdateColliderSize();
        }
    }
}
