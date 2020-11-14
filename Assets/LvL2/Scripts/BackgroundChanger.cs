using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class BackgroundChanger : MonoBehaviour
{

    private LapseTimer lapseTimer;
    [SerializeField] private GameObject background1;
    [SerializeField] private GameObject background2;
    [SerializeField] private GameObject estatua1;
    [SerializeField] private GameObject estatua2;
    [SerializeField] private Text timerText;
    [SerializeField] private CinemachineVirtualCamera cinemachine;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private CheckIfEndLevel checkIfEndLevel;

    void Start()
    {
        estatua1.GetComponent<Animator>().SetTrigger("Deterioro");
        estatua2.GetComponent<Animator>().SetTrigger("Deterioro");
        lapseTimer = gameObject.AddComponent<LapseTimer>();
        lapseTimer.Lapse = 10f;
        lapseTimer.Run();
    }

    private void Update()
    {
        timerText.text = ((int)lapseTimer.elapsedSeconds).ToString();
        if(checkIfEndLevel.gotSculptures!=2)
        {
            if((int)lapseTimer.elapsedSeconds==40){
                lapseTimer.elapsedSeconds=41f;
                background1.SetActive(false);
                background2.SetActive(true);

                Animator anim;
                if(estatua1.TryGetComponent<Animator>(out anim) &&estatua2.TryGetComponent<Animator>(out anim))
                    StartCoroutine(startCutsceneTrigger("Deterioro2")); 
            }
            else if((int)lapseTimer.elapsedSeconds==80){
                lapseTimer.elapsedSeconds=81f;
                background1.SetActive(true);
                background2.SetActive(false);   

                Animator anim;
                if(estatua1.TryGetComponent<Animator>(out anim) &&estatua2.TryGetComponent<Animator>(out anim))
                StartCoroutine(startCutsceneTrigger("Deterioro3"));
            }
            else if((int)lapseTimer.elapsedSeconds==120){
                lapseTimer.elapsedSeconds=121f;
                background1.SetActive(false);
                background2.SetActive(true);

                Animator anim;
                if(estatua1.TryGetComponent<Animator>(out anim) &&estatua2.TryGetComponent<Animator>(out anim))
                StartCoroutine(startCutsceneTrigger("Deterioro4"));
            }
        }
        else
        {
           if((int)lapseTimer.elapsedSeconds==120){
                Time.timeScale=0f;
                endScreen.SetActive(true);
            } 
        }
    }
    IEnumerator startCutsceneTrigger(string triggerToActivate){
        
        StairClimber playerMove = GameObject.Find("Restorer").GetComponent<StairClimber>();
        playerMove.stopMovement();
        playerMove.canMove = false;
        lapseTimer.isRunning = false;

        cinemachine.Follow = estatua1.transform;
        estatua1.GetComponent<Animator>().SetTrigger(triggerToActivate);
        yield return new WaitForSeconds(3);

        cinemachine.Follow = estatua2.transform;
        estatua2.GetComponent<Animator>().SetTrigger(triggerToActivate);
        yield return new WaitForSeconds(3);

        cinemachine.Follow = GameObject.Find("Restorer").transform;
        lapseTimer.isRunning = true;

        if(triggerToActivate.Equals("Deterioro4")){
            Time.timeScale=0f;
            playerMove.canMove = false;
            endScreen.SetActive(true);
        }
        else
            playerMove.canMove = true;
    }
}
