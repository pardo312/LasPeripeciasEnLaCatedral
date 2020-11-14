using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoSceneChanger : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Button btn;
    [SerializeField] private string nextVideoSceneName;

    private void Start()
    {
        if(nextVideoSceneName=="")
            videoPlayer.loopPointReached += ClickButton;
        else
            videoPlayer.loopPointReached += nextPart;
    }
    private void nextPart(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextVideoSceneName);
    }
    private void ClickButton(VideoPlayer vp)
    {
        btn.onClick.Invoke();
    }
}
