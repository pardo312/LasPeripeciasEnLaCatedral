using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfWinGame : IntEventInvoker
{
    private bool finishedGame = false;
    private bool endGame = false;
    private GameWonEvent gameWonEvent = new GameWonEvent();
    // Start is called before the first frame update
    void Awake()
    {
        unityEvents.Add(EventName.GameWonEvent, gameWonEvent);
        EventManager.AddInvoker(EventName.GameWonEvent, this);
        for(int i = 0; i<4;i++)
        {
            transform.GetChild(Random.Range(0,transform.childCount)).GetComponent<DirtManager>().hasDirt=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!endGame){
            finishedGame=true;
            foreach (Transform child in transform)
            {
                if(child.GetComponent<DirtManager>().hasDirt){
                    finishedGame = false;
                }
            }
        }
        if(finishedGame){
            gameWonEvent.Invoke(0);
            Cursor.visible = true;
            finishedGame=false;
            endGame=true;
        }
    }
}
