using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Lvl3GameOverMenu : MonoBehaviour
{
    [SerializeField] private List<Image> lifeImages = new List<Image>();
    [SerializeField] private Text stateText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button restartButton;

    private int lifes;
    private int score;
    private bool won;
    private UnityAction playButtonOnClick;
    private UnityAction restartButtonOnClick;

    public void Initialize(int lifes, int score, bool won, UnityAction playButtonOnClick, UnityAction restartButtonOnClick)
    {
        this.lifes = lifes;
        this.score = score;
        this.won = won;
        this.playButtonOnClick = playButtonOnClick;
        this.restartButtonOnClick = restartButtonOnClick;
    }

    private void Start()
    {
        for (int i = lifes; i < lifeImages.Count; i++)
        {
            lifeImages[i].color = new Color(0, 0, 0, 100f);
        }

        if (lifes >= 1)
        {
            if (won)
            {
                stateText.text = "Muy Bien Hecho!";
                if (score >= 100)
                {
                    StartCoroutine(ScoreAnim());
                }
            }
            else
            {
                stateText.text = "Sigue Intentando!";
                scoreText.text = score.ToString();
            }

            playButton.gameObject.SetActive(true);
            playButton.onClick.AddListener(playButtonOnClick);

        }
        else
        {
            scoreText.text = score.ToString();
            stateText.text = "Qué mal, vuelve a intentarlo!";
            restartButton.gameObject.SetActive(true);
            restartButton.onClick.AddListener(restartButtonOnClick);
        }

        homeButton.onClick.AddListener(HandleHomeButtonOnClickEvent);
    }

    private void HandleHomeButtonOnClickEvent()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator ScoreAnim()
    {
        int initScore = score - 100;
        scoreText.text = initScore.ToString();
        int i = 1;
        while(i <= 100)
        {
            initScore += 1;
            scoreText.text = initScore.ToString();
            yield return new WaitForEndOfFrame();
            i += 1;
        }
    }
}
