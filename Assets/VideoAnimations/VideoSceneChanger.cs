using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoSceneChanger : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Button btn;

    private void Start()
    {
        videoPlayer.loopPointReached += ClickButton;
    }

    private void ClickButton(VideoPlayer vp)
    {
        btn.onClick.Invoke();
    }
}
