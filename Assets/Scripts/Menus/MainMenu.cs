using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Handles the onClcik event from the LVL1 button
    /// </summary>
    public void HandleLvL1ButtonOnClickEvent()
    {
        SceneManager.LoadScene(SceneName.LvL1Alpha.ToString());
    }

    public void HandleVideo1ButtonOnClickEvent()
    {
        SceneManager.LoadScene(SceneName.Video1.ToString());
    }

    public void HandleVideo11ButtonOnClickEvent()
    {
        SceneManager.LoadScene("Video1.1");
    }

    public void HandleVideo12ButtonOnClickEvent()
    {
        SceneManager.LoadScene("Video1.2");
    }

    public void HandleVideo2ButtonOnClickEvent()
    {
        SceneManager.LoadScene(SceneName.Video2.ToString());
    }
    public void HandleVideo3ButtonOnClickEvent()
    {
        SceneManager.LoadScene(SceneName.Video3.ToString());
    }

    public void HandleMainMenuButtonOnClickEvent()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }

    public void HandleCreditsButtonOnClickEvent()
    {
        SceneManager.LoadScene(SceneName.Credits.ToString());
    }


    /// <summary>
    /// Handles the onClcik event from the LVL2 button
    /// </summary>
    public void HandleLvL2ButtonOnClickEvent()
    {
        SceneManager.LoadScene(SceneName.LvL2Alpha.ToString());
    }

    public void HandleLvL3ButtonOnClickEvent()
    {
        SceneManager.LoadScene(SceneName.Lvl3InitScene.ToString());
    }
}
