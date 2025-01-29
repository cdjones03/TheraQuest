using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] public GameObject moodUI;
    [SerializeField] public GameObject coinUI;
    [SerializeField] public GameObject heart;
    [SerializeField] public GameObject player;
    
    public TextMeshProUGUI moodText;
    public TextMeshProUGUI coinText;
    public Animator animator;
    public PlayerManager manager;

# region Animation Variables
    public int stableThreshold = 85;
    public int hurtThreshold = 60;
    public int lowThreshold = 30;
    public int emptyThreshold = 15;
    #endregion
 // this is a duplicate of the first few lines of update because unity would throw a fit otherwise
    private void Awake()
    {
        
        coinText.text = manager.curCoins.ToString();
        moodText.text = manager.curMoodValue.ToString();
        animator.SetFloat("mood", manager.curMoodValue);
        animator.SetBool("stable", true);

    }
    void Start()
    {
        manager = player.GetComponent<PlayerManager>();
        //moodText = moodUI.GetComponent<TextMeshProUGUI>();
        //coinText = coinUI.GetComponent<TextMeshProUGUI>();
        animator = heart.GetComponent<Animator>();

        coinText.text = manager.curCoins.ToString();
        moodText.text = manager.curMoodValue.ToString();
        animator.SetFloat("mood", manager.curMoodValue);

        
        //manager = FindFirstObjectByType<PlayerManager>();
        

        //coinText.text = manager.curCoins.ToString();
        //moodText.text = manager.curMoodValue.ToString();

        animator.SetBool("stable", false);
        animator.SetBool("hurt", false);
        animator.SetBool("low", false);
        animator.SetBool("empty", false);
    }

   

    private void Update()
    {
        animator.SetFloat("mood", manager.curMoodValue);
        coinText.text = manager.curCoins.ToString();
        moodText.text = manager.curMoodValue.ToString();

        if (manager.curMoodValue >= stableThreshold)
        {
            animator.SetBool("stable", true);
        }
        else if (manager.curMoodValue >= hurtThreshold)
        {
            animator.SetBool("stable", false);
            animator.SetBool("hurt", true);
        }
        else if (manager.curMoodValue >= lowThreshold)
        {
            animator.SetBool("hurt", false);
            animator.SetBool("low", true);
        }
        else if (manager.curMoodValue < emptyThreshold)
        {
            animator.SetBool("low", false);
            animator.SetBool("empty", true);
        }
        else
        {
            animator.SetBool("empty", true);
            Debug.Log("Something went wrong while assigning animation states.");
        }
    }
}
