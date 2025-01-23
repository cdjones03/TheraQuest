using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int curMoodValue;
    public int maxMoodValue;

    public int curCoins;
    public int income;

    public TextMeshProUGUI curCoinsText;
    public Slider moodSlider;

    private float moodTimer = 0f;
    private float moodDecreaseInterval = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curCoins = 0;
        curCoinsText.text = curCoins.ToString();

        maxMoodValue = 10;
        curMoodValue = maxMoodValue;
        moodSlider.value = curMoodValue;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle mood decrease timer
        moodTimer += Time.deltaTime;
        if (moodTimer >= moodDecreaseInterval)
        {
            moodTimer = 0f;  // Reset timer
            AddMood(-1);     // Decrease mood by 1
            moodSlider.value = curMoodValue;  // Update the slider
        }
    }

    public void AddMood(int amount)
    {
        curMoodValue += amount;
        if (curMoodValue > maxMoodValue)
        {
            curMoodValue = maxMoodValue;
        }
        else if (curMoodValue < 0)  // Added to prevent negative mood
        {
            curMoodValue = 0;
        }
        moodSlider.value = curMoodValue;  // Update slider whenever mood changes
    }

    public void AddCoin(){
        curCoins += 1;
        curCoinsText.text = curCoins.ToString();
    }
}
