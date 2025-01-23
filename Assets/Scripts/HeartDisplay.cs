using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] public GameObject heartOne;
    [SerializeField] public GameObject heartTwo;    
    [SerializeField] public GameObject heartThree;
    [SerializeField] public GameObject heartFour;

   
    void Start()
    {
        heartOne.SetActive(false);
        heartTwo.SetActive(false);
        heartThree.SetActive(false);
        heartFour.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //only one heart is active
        if (TherapistCounter.totalVisits == 1)
        {
            heartOne.SetActive(true);
        }
        //two hearts are active
        if (TherapistCounter.totalVisits == 2)
        {
            heartOne.SetActive(true); 
            heartTwo.SetActive(true);
        }
        //three hearts are active
        if (TherapistCounter.totalVisits == 3)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true); 
            heartThree.SetActive(true);
        }
        //four hearts are active
        if (TherapistCounter.totalVisits == 4)
        {
            heartOne.SetActive(true);
            heartTwo.SetActive(true);
            heartThree.SetActive(true); 
            heartFour.SetActive(true);
        }
    }
}
