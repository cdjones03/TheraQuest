using UnityEngine;

public class AnimationToggle : MonoBehaviour
{
    public Animator animator;
    public bool flash;
    public bool glow;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (flash)
        { 
            animator.SetBool("Flash", true);   
        } 
        else
        {
            animator.SetBool("Flash", false);
        }

        if (glow)
        {   
            animator.SetBool("Glow", true);
        }
        else
        {
            animator.SetBool("Glow", false);
        }
    }
}
