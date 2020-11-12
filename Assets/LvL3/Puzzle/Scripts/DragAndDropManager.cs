using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragAndDropManager : IntEventInvoker
{
    [SerializeField] private List<Transform> initPositions;
    [SerializeField] private List<GameObject> items;
    private int finishedItems = 0;

    private GameWonEvent gameWonEvent = new GameWonEvent();

    private void Start()
    {
        unityEvents.Add(EventName.gameWonEvent, gameWonEvent);
        EventManager.AddInvoker(EventName.gameWonEvent, this);

        initPositions = initPositions.OrderBy(a => Guid.NewGuid()).ToList();
        for(int i = 0; i < initPositions.Count; i++)
        {
            items[i].transform.position = initPositions[i].position;
        }
    }

    public void AddFinishedItem()
    {
        finishedItems++;
        if(finishedItems == items.Count)
        {
            gameWonEvent.Invoke(0);
        }
    }
}
