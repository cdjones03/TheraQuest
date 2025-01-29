
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] theraSpawnPoint;
    [SerializeField] private GameObject[] therapyRooms;
    [SerializeField] private GameObject teleport;
    
    private float playerX;
    private float playerY;
    private float therapistX;
    private float therapistY;
    private Transform position;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        teleport = GameObject.FindGameObjectWithTag("Teleport");
        
        theraSpawnPoint = new GameObject[5];
        therapyRooms = new GameObject[5];
        
        GetComponent<Collider2D>().isTrigger = true;
        
        position = this.gameObject.transform;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        therapistX = 0;
        therapistY = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int rand = UnityEngine.Random.Range(0, 4);
        // ReSharper disable once InvertIf
        if (other.gameObject.CompareTag("Player"))
        {
            playerX = player.transform.position.x;
            playerY = player.transform.position.y;
            player.transform.position = theraSpawnPoint[rand].transform.position;
            Debug.Log("firing teleport");
            //do we want destroy.gameobject here?
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Reset(true);
        }
    }

    void Reset(bool reset)
    {
        throw new NotImplementedException();
        //go to most recent pill location -- https://www.gamedeveloper.com/programming/unity---creating-a-checkpoints-system??
    }
}
