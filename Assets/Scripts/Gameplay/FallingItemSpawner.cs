using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItemSpawner : MonoBehaviour
{
    private FallingItem[] fallingItems;

    private void Awake()
    {
        
    }

    private void PopulateItems()
    {
        Object[] items = Resources.LoadAll(GameConstants.FallingItemsResourcesPath);
        fallingItems = new FallingItem[items.Length];
    }
}
