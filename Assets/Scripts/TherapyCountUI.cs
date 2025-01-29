using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class TherapyCountUI : MonoBehaviour
{
    TextMeshProUGUI counterText;
    [SerializeField] public GameObject pillOne;
    [SerializeField] public GameObject pillTwo;
    [SerializeField] public GameObject pillThree;
    [SerializeField] public GameObject pillFour;
    [SerializeField] public GameObject pillFive;

    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
        pillOne.SetActive(false);
        pillTwo.SetActive(false);
        pillThree.SetActive(false);
        pillFour.SetActive(false);
        pillFive.SetActive(false);
    }

    public void UpdateText()
    {
        counterText.text = ("You have visited " + TherapistCounter.totalVisits.ToString() + " providers.");
    }

    void Update()
    {
        //only one visit
        if (TherapistCounter.totalVisits == 1)
        {
            pillOne.SetActive(true);
        }
        //two visits
        if (TherapistCounter.totalVisits == 2)
        {
            pillOne.SetActive(true);
            pillTwo.SetActive(true);
        }
        //three visits
        if (TherapistCounter.totalVisits == 3)
        {
            pillOne.SetActive(true);
            pillTwo.SetActive(true);
            pillThree.SetActive(true);
        }
        //four visits
        if (TherapistCounter.totalVisits == 4)
        {
            pillOne.SetActive(true);
            pillTwo.SetActive(true);
            pillThree.SetActive(true);
            pillFour.SetActive(true);
        }
        //five visits
        if (TherapistCounter.totalVisits == 5)
        {
            pillOne.SetActive(true);
            pillTwo.SetActive(true);
            pillThree.SetActive(true);
            pillFour.SetActive(true);
            pillFive.SetActive(true);
        }
    }
}