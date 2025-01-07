using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(TMP_InputField))]
public class DynamicTextCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private TMP_InputField inputField;
    
    [SerializeField] private Vector2 padding = new Vector2(10f, 10f); // Extra space around the text
    [SerializeField] private float leftOffset = 0f; // Distance from left edge to start the collider

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

        // Get the preferred size of the text
        Vector2 textSize = inputField.textComponent.GetPreferredValues();
        
        // Add padding
        textSize += padding;

        // Update the collider size
        boxCollider.size = textSize;
        
        // Set offset to anchor on the left
        boxCollider.offset = new Vector2(leftOffset + (textSize.x / 2f), -textSize.y / 2f);
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
