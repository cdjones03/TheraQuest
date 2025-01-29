using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistCounter : MonoBehaviour
{

    [SerializeField] private GameObject player;
    //static = accessible from any script)
    public static int totalVisits = 0;

    public int copayValue;
    public TherapyCountUI ui;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
        //declare type?? findobjectoftype? so confused
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        copayValue = 3;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int curCoins = player.GetComponent<PlayerManager>().getCurCoins();

        //Destroy the coin if Object tagged Player comes in contact with it
        if (other.CompareTag("Player") && curCoins >= copayValue)
        {
            //Add visit to counter
            totalVisits++;
            Debug.Log("You have seen " + TherapistCounter.totalVisits + " providers.");
            ui.UpdateText(); 
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