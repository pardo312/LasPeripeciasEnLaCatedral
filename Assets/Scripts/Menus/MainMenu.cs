using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandleLvL1ButtonOnClickEvent()
    {
        SceneManager.LoadScene(1);
    }

    public void HandleLvL2ButtonOnClickEvent()
    {
        SceneManager.LoadScene(2);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
}
