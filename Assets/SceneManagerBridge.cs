using UnityEngine;

public class SceneManagerBridge : MonoBehaviour
{

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
     public void LoadNextScene()
    {
        SceneLoader.LoadNextScene();
    }

    public void LoadStartMenu()
    {
        SceneLoader.LoadSpecificScene(SceneLoader.SceneNames.StartMenu);
    }

    public void LoadGameScene()
    {
        SceneLoader.LoadSpecificScene(SceneLoader.SceneNames.GameScene);
    }

    public void LoadEndMenu()
    {
        SceneLoader.LoadSpecificScene(SceneLoader.SceneNames.EndMenu);
    }

    public void RestartCurrentScene()
    {
        SceneLoader.RestartCurrentScene();
    }
}
