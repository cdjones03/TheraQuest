using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TherapyCountUI : MonoBehaviour
{
    Text counterText;
    void Start()
    {
        counterText = GetComponent<Text>();
    }

    public void UpdateText()
    {
        counterText.text = ("You have visited " + TherapistCounter.totalVisits.ToString() + " providers.");
    }
}