using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale =0f;
    }
    public void continueGame()
    {
        Time.timeScale =1f;
        gameObject.SetActive(false);
    }
}
