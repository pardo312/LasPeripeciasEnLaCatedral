using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    [SerializeField] private List<Transform> initPositions;
    [SerializeField] private List<GameObject> items;

    private void Start()
    {
        initPositions = initPositions.OrderBy(a => Guid.NewGuid()).ToList();
        for(int i = 0; i < initPositions.Count; i++)
        {
            items[i].transform.position = initPositions[i].position;
        }
    }
}
