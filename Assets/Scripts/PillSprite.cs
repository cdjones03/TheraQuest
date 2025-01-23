using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PillSprite : MonoBehaviour
{
    [SerializeField] public Sprite baseSprite;
    [SerializeField] public Sprite glowSprite;
    [SerializeField] public Sprite clickedSprite;
    private SpriteRenderer baseSpr, glowSpr, clickSpr;

    void Start()
    {
        baseSpr = baseSprite.GetComponent<SpriteRenderer>();
        glowSpr = glowSprite.GetComponent<SpriteRenderer>();
        clickSpr = clickedSprite.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if pill is within player's detection radius
        if (collision.gameObject.CompareTag("Detect"))
        {
            baseSpr.enabled = true;
            glowSpr.enabled = true;
        }

        // if player collides with pill
        if (collision.gameObject.CompareTag("Player"))
        {
            baseSpr.enabled = false;
            glowSpr.enabled = false;
            clickSpr.enabled = true;
        }
    }
}
