using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{

    private LapseTimer lapseTimer;
    [SerializeField] private GameObject background1;
    [SerializeField] private GameObject background2;
    [SerializeField] private Text timerText;

    void Start()
    {
        lapseTimer = gameObject.AddComponent<LapseTimer>();
        lapseTimer.Lapse = 10f;
        lapseTimer.AddTimerLapseListener(ChangeBackground);
        lapseTimer.Run();
    }

    private void Update()
    {
        timerText.text = ((int)lapseTimer.elapsedSeconds).ToString();
    }

    private void ChangeBackground()
    {
        if (background1.activeSelf)
        {
            background1.SetActive(false);
            background2.SetActive(true);
        }
        else{
            background1.SetActive(true);
            background2.SetActive(false);
        }
    }
}
