using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] public GameObject heart;
   
    void Start()
    {
        heart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //only one heart is active
        if (TherapistCounter.totalVisits == 1)
        {
            heart.SetActive(true);
        }
    }
}
