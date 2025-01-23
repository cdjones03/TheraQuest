using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance is null)
                Debug.LogError("Game Manager is NULL");

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
