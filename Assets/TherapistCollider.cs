using UnityEngine;

public class TherapistCollider : MonoBehaviour
{
    public int copayValue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        copayValue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
    }
}
