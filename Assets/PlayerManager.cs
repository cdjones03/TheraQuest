using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int curCoins;
    public int curMoodValue;
    public int income;
    public int maxMoodValue = 100;

    private float moodTimer = 0f;
    private float moodDecreaseInterval = 10f;

    public Vector3 lastPosition;

    //UpdateUI updateUI;

    void Start()
    {
        curCoins = 0;
        curMoodValue = maxMoodValue;
        //updateUI = FindFirstObjectByType<UpdateUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle mood decrease timer
        moodTimer += Time.deltaTime;
        if (moodTimer >= moodDecreaseInterval)
        {
            moodTimer = 0f;                                     // Reset timer
            AddMood(-1);                                        // Decrease mood by 1
            //updateUI.moodText.text = curMoodValue.ToString(); // Update UI
        }
    }

    public void AddMood(int amount)
    {
        curMoodValue += amount;
        if (curMoodValue > maxMoodValue)
        {
            curMoodValue = maxMoodValue;
        }
        else if (curMoodValue < 0)                              // Added to prevent negative mood
        {
            curMoodValue = 0;
        }
        //updateUI.moodText.text = curMoodValue.ToString();     // Update UI whenever mood changes
    }

    public void AddCoin()
    {
        curCoins ++;
        //updateUI.coinText.text = curCoins.ToString();         // Update UI
    }

    public void SetLastPosition(Vector3 position)
    {
        lastPosition = position;
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        // would we need a script on the player for this...?? 
        if (other.gameObject.CompareTag("Door"))
        {
            transform.position = lastPosition;
        }
    }
}
