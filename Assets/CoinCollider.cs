using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerManager>().AddCoin();
            Destroy(gameObject);
            Debug.Log("Coin collected!");
        }
    }
}
