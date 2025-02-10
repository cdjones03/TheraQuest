using UnityEngine;
using UnityEngine.SceneManagement;

public class Killbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().goToLastPosition();
        }
    }
}
