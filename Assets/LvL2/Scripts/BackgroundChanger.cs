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
        if((int)lapseTimer.elapsedSeconds==30){
            lapseTimer.elapsedSeconds=31f;
            background1.SetActive(false);
            background2.SetActive(true);
            MusicManager musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();  
            musicManager.SpeedUpSong(0.3f);
            StartCoroutine(startCutsceneTrigger("Deterioro2")); 
        }
        else if((int)lapseTimer.elapsedSeconds==60){
            lapseTimer.elapsedSeconds=61f;
            background1.SetActive(true);
            background2.SetActive(false);
            MusicManager musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();  
            musicManager.SpeedUpSong(0.3f);  
            StartCoroutine(startCutsceneTrigger("Deterioro3"));
        }
        else if((int)lapseTimer.elapsedSeconds==90){
            lapseTimer.elapsedSeconds=91f;
            background1.SetActive(false);
            background2.SetActive(true);
            MusicManager musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();  
            musicManager.SpeedUpSong(0.3f);
            StartCoroutine(startCutsceneTrigger("Deterioro4"));
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
        
        //Que asco de codigo ;_v no merezco ni progamar xd
        Animator anim;
        MusicManager musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();  
        musicManager.SpeedUpSong(0.3f);
        StairClimber playerMove = GameObject.Find("Restorer").GetComponent<StairClimber>();
        playerMove.stopMovement();
        if(estatua2.TryGetComponent<Animator>(out anim) || estatua1.TryGetComponent<Animator>(out anim)){
            SoundFXManager soundFXManager = GameObject.Find("SoundFXManager").GetComponent<SoundFXManager>();
            soundFXManager.StopPlayingAll();
            playerMove.canMove = false;
            lapseTimer.isRunning = false;
        }
        if(estatua1.TryGetComponent<Animator>(out anim)){
            cinemachine.Follow = estatua1.transform;
            estatua1.GetComponent<Animator>().SetTrigger(triggerToActivate);
            yield return new WaitForSeconds(3);
        }
        if(estatua2.TryGetComponent<Animator>(out anim)){
            cinemachine.Follow = estatua2.transform;
            estatua2.GetComponent<Animator>().SetTrigger(triggerToActivate);
            yield return new WaitForSeconds(3);
        }

        if(estatua2.TryGetComponent<Animator>(out anim) || estatua1.TryGetComponent<Animator>(out anim)){
            cinemachine.Follow = GameObject.Find("Restorer").transform;
            lapseTimer.isRunning = true;
            if(triggerToActivate.Equals("Deterioro4")){
                Time.timeScale=0f;
                playerMove.canMove = false;
                endScreen.SetActive(true);
                musicManager.StopPlayingAll();
                musicManager.Play("MusicLost");
            }
            else
                playerMove.canMove = true;

        }

    }
}
