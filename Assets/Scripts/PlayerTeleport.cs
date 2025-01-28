
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject theraSpawnPoint;
    [SerializeField] private GameObject teleport;
    private float playerX;
    private float playerY;
    private float therapistX;
    private float therapistY;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        teleport = GameObject.FindGameObjectWithTag("Teleport");
        theraSpawnPoint = GameObject.FindGameObjectWithTag("TheraSpawn");
        GetComponent<Collider2D>().isTrigger = true;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        therapistX = theraSpawnPoint.transform.position.x;
        therapistY = theraSpawnPoint.transform.position.y;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ReSharper disable once InvertIf
        if (other.gameObject.CompareTag("Player"))
        {
            playerX = player.transform.position.x;
            playerY = player.transform.position.y;
            player.transform.position = theraSpawnPoint.transform.position;
            Debug.Log("firing teleport");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Reset(true);
        }
    }

    void Reset(bool reset)
    {
        throw new NotImplementedException();
    }
}
