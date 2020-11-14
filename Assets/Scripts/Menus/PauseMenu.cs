using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the onClick events for the pause menu buttons
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private SceneName currentScene;
    [SerializeField] private SceneName nextScene;

    /// <summary>
    /// Pauses the game when added to the scene
    /// </summary>
    private void Start()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Handles the on click event from the resume button
    /// </summary>
    public void HandleResumeOnClickEvent()
    {
        //unpause game and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleRestartButtonOnClickEvent()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene.ToString());
    }

    public void HandleContinueButtonOnClickEvent()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nextScene.ToString());
    }

    /// <summary>
    /// Hanldes the onClick event from the quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        //unpause the game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
