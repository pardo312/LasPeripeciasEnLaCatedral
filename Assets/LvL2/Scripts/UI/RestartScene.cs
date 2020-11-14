using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    // Update is called once per frame
    public void restartScene()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }
    public void nextScene()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneName.Video2.ToString());
    }
}
