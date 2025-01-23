using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistCounter : MonoBehaviour
{
    //static = accessible from any script)
    public static int totalVisits = 0;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (other.CompareTag("Player"))
        {
            //Add visit to counter
            totalVisits++;
            Debug.Log("You have seen " + TherapistCounter.totalVisits + " providers.");
            Loading();
        }
    }

    void Loading()
    {
        // SET CHECKPOINT FLAG
        // LOAD NEXT SCENE
        this.enabled = false;
    }
}