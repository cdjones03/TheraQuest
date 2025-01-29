using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static class SceneNames
    {
        public const string StartMenu = "StartMenu";
        public const string GameScene = "GameSceneME";
        public const string EndMenu = "EndMenu";
    }

    public static void LoadNextScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        switch (currentScene)
        {
            case SceneNames.StartMenu:
                SceneManager.LoadScene(SceneNames.GameScene);
                break;
                
            case SceneNames.GameScene:
                SceneManager.LoadScene(SceneNames.EndMenu);
                break;
                
            case SceneNames.EndMenu:
                SceneManager.LoadScene(SceneNames.StartMenu);
                break;
                
            default:
                Debug.LogWarning($"Unknown scene: {currentScene}. Loading StartMenu.");
                SceneManager.LoadScene(SceneNames.StartMenu);
                break;
        }
    }

    public static void LoadSpecificScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
