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

    /// <summary>
    /// Handles the onClcik event from the LVL2 button
    /// </summary>
    public void HandleLvL2ButtonOnClickEvent()
    {
        SceneManager.LoadScene(SceneName.LvL2Alpha.ToString());
    }
}
