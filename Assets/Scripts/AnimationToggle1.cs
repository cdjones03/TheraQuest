using UnityEngine;

public class AnimationToggle1 : MonoBehaviour
{
    public Animator animator;
    public bool stable;
    public bool hurt;
    public bool low;
    public bool empty;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // ugly as hell lol
    void Update()
    {
        if (stable)
        { 
            animator.SetBool("stable", true);   
        } 
        else
        {
            animator.SetBool("stable", false);
        }

        if (hurt)
        {
            animator.SetBool("stable", false); 
            animator.SetBool("hurt", true);
        }
        else
        {
            animator.SetBool("hurt", false);
        }

        if (low)
        {
            animator.SetBool("hurt", false); 
            animator.SetBool("low", true);
        }
        else
        {
            animator.SetBool("low", false);
        }

        if (empty)
        {
            animator.SetBool("low", false); 
            animator.SetBool("empty", true);
        }
        else
        {
            animator.SetBool("empty", false);
        }
    }
}
