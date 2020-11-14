using UnityEngine;

public class PauseMenuInvoker : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void HandleOnClickEvent()
    {
        Instantiate(pauseMenu);
    }
}
