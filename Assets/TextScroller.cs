using UnityEngine;
using UnityEngine.UI;
public class TextScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 100f;
    [SerializeField] private RectTransform canvasRect;
    [SerializeField] private float spacing = 50f;  // Space between text objects
    [SerializeField] private int textIndex = 0;    // Set different index for each text copy
    private RectTransform textRectTransform;
    private float textWidth;
    private float canvasWidth;
    private Vector2 startPosition;

    void Start()
    {
        textRectTransform = GetComponent<RectTransform>();
        textWidth = textRectTransform.rect.width;
        canvasWidth = canvasRect.rect.width;
        
        // Start at the left edge of the canvas (0), offset by index
        float startX = 300 - (textWidth + spacing) + (spacing * textIndex);
        startPosition = new Vector2(startX, textRectTransform.anchoredPosition.y);
        textRectTransform.anchoredPosition = startPosition;
    }

    void Update()
    {
        textRectTransform.anchoredPosition += new Vector2(scrollSpeed * Time.deltaTime, 0);
        
        // Reset when text moves past right edge of canvas
        if (textRectTransform.anchoredPosition.x > canvasWidth)
        {
            textRectTransform.anchoredPosition = startPosition;
        }
    }
}