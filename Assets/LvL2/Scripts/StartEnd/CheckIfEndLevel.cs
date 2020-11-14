using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfEndLevel : MonoBehaviour
{
    [HideInInspector]public int gotSculptures = 0;
    [SerializeField]private GameObject WinUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gotSculptures==2){
                MusicManager musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
                musicManager.StopPlayingAll();
                musicManager.Play("MusicWin");
                Time.timeScale = 0f;
                WinUI.SetActive(true);
            }
        }
    }
}
