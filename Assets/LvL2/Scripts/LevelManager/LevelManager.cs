using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicManager musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        musicManager.Play("MusicLVL2");
    }

}
