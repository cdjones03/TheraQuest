using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] public GameObject heartOne;
    [SerializeField] public GameObject heartTwo;    
    [SerializeField] public GameObject heartThree;
    [SerializeField] public GameObject heartFour;
    private bool one, two, three, four = false;

   
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
        if (one)
        {
            heartOne.SetActive(true);
        }
        //two hearts are active
        if (two)
        {
            one = false;
            heartTwo.SetActive(true);
        }
        //three hearts are active
        if (three)
        {
            two = false;
            heartThree.SetActive(true);
        }
        //four hearts are active
        if (four)
        {
            three = false;
            heartFour.SetActive(true);
        }
    }
}
