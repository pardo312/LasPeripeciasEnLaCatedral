using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Lvl3GameOverMenu : MonoBehaviour
{
    [SerializeField] private List<Image> lifeImages = new List<Image>();
    [SerializeField] private Text scoreText;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button restartButton;

    private int lifes;
    private int score;
    private UnityAction playButtonOnClick;
    private UnityAction restartButtonOnClick;

    public void Initialize(int lifes, int score, UnityAction playButtonOnClick, UnityAction restartButtonOnClick)
    {
        this.lifes = lifes;
        this.score = score;
        this.playButtonOnClick = playButtonOnClick;
        this.restartButtonOnClick = restartButtonOnClick;
    }

    private void Start()
    {
        for (int i = lifes; i < lifeImages.Count; i++)
        {
            lifeImages[i].color = new Color(0, 0, 0, 100f);
        }

        scoreText.text = score.ToString();

        if (lifes >= 1)
        {
            playButton.gameObject.SetActive(true);
            playButton.onClick.AddListener(playButtonOnClick);

        }
        else
        {
            restartButton.gameObject.SetActive(true);
            restartButton.onClick.AddListener(restartButtonOnClick);
        }

        homeButton.onClick.AddListener(HandleHomeButtonOnClickEvent);
    }

    private void HandleHomeButtonOnClickEvent()
    {
        SceneManager.LoadScene(0);
    }
}
