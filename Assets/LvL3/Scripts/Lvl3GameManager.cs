using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl3GameManager : MonoBehaviour
{

    [SerializeField] private List<MiniGame> miniGames = new List<MiniGame>();
    private int currentMiniGameIndex;
    private bool tutorial = true;

    [SerializeField] private GameObject slider;
    private GameObject instantiatedSlider;
    [SerializeField] private GameObject GameOverMenu;

    private int score;
    private int lifes;

    private void Start()
    {
        Initialize();
        EventManager.AddListener(EventName.gameWonEvent, HandleGameWonEvent);
        EventManager.AddListener(EventName.gameLostEvent, HandleGameLostEvent);
        DontDestroyOnLoad(this);
    }

    private void Initialize()
    {
        currentMiniGameIndex = 0;
        tutorial = true;
        score = 0;
        lifes = 3;
        LoadNextMiniGameScene();
    }

    private void InstantiateGameOverMenu()
    {
        GameObject gameOverMenu = Instantiate(GameOverMenu);
        gameOverMenu.GetComponent<Lvl3GameOverMenu>().Initialize(lifes, score, LoadNextMiniGame, Initialize);
    }

    private void HandleGameWonEvent(int minigameScore)
    {
        score += minigameScore;
        InstantiateGameOverMenu();
    }

    private void HandleGameLostEvent(int unused)
    {
        lifes -= 1;
        InstantiateGameOverMenu();
    }

    private void LoadNextMiniGame()
    {
        if (tutorial && currentMiniGameIndex < miniGames.Count - 1)
        {
            currentMiniGameIndex++;
        }
        else
        {
            tutorial = false;
            int oldMinigameIndex = currentMiniGameIndex;
            do
            {
                currentMiniGameIndex = Random.Range(0, miniGames.Count);
            }
            while (oldMinigameIndex == currentMiniGameIndex);
        }

        LoadNextMiniGameScene();
    }

    private void LoadNextMiniGameScene()
    {
        Destroy(instantiatedSlider);
        instantiatedSlider = Instantiate(slider, transform);
        instantiatedSlider.transform.GetChild(0).GetComponent<SliderTimer>().Initialize(miniGames[currentMiniGameIndex].InitialDuration);
        SceneManager.LoadScene(miniGames[currentMiniGameIndex].sceneName);
    }
}
