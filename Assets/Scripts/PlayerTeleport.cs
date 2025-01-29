
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] theraSpawnPoint;
    [SerializeField] private GameObject[] therapyRooms;
    //[SerializeField] private GameObject teleport;
    
    private float playerX;
    private float playerY;
    private float therapistX;
    private float therapistY;
    private Transform pillPosition;

    public static int roomOrder = 0;

    public int copayValue;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //teleport = GameObject.FindGameObjectWithTag("Teleport");
        
        //theraSpawnPoint = new GameObject[5];
        //therapyRooms = new GameObject[5];
        
        GetComponent<Collider2D>().isTrigger = true;
        
        pillPosition = this.gameObject.transform;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        therapistX = 0;
        therapistY = 0;

        copayValue = 3;

        reshuffle(therapyRooms);
    }

    void reshuffle(GameObject[] rooms)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        // reorganizes array randomly (we hope)
        for (int t = 0; t < rooms.Length; t++)
        {
            GameObject tmp = rooms[t];
            int r = Random.Range(t, rooms.Length);
            rooms[t] = rooms[r];
            rooms[r] = tmp;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int rand = UnityEngine.Random.Range(0, 4);
        int curCoins = player.GetComponent<PlayerManager>().getCurCoins();
        // ReSharper disable once InvertIf
        if (other.gameObject.CompareTag("Player") && curCoins >= copayValue)
        {
            player.GetComponent<PlayerManager>().SubtractCoin(copayValue);

            therapistX = transform.position.x;
            therapistY = transform.position.y;
            playerX = player.transform.position.x;  
            playerY = player.transform.position.y;
            //runs through the array in order (0-4)
            //but since the value is randomized, it should still work without duplicates
            player.transform.position = theraSpawnPoint[roomOrder].transform.position;
            Debug.Log("firing teleport");

            player.GetComponent<PlayerManager>().SetLastPosition(transform.position);
            roomOrder += 1;
            Destroy(gameObject);
        }


        /*
        // would we need a script on the player for this...?? 
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("firing door");
            Reset(true);
            player.transform.position = pillPosition.transform.position;
            roomOrder += 1;
            Destroy(this);
        }
        */
    }

    void Reset(bool reset)
    {
        player.transform.position = new Vector2(therapistX, therapistY);
        //go to most recent pill location -- https://www.gamedeveloper.com/programming/unity---creating-a-checkpoints-system??
    }
}
