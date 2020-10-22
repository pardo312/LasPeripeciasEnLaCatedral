using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItemSpawner : MonoBehaviour
{
    private FallingItem[] fallingItems;

    private void Awake()
    {
        PopulateItems();
    }

    private void PopulateItems()
    {
        Object[] items = Resources.LoadAll(GameConstants.FallingItemsResourcesPath, typeof(FallingItem));
        fallingItems = new FallingItem[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            fallingItems[i] = items[i] as FallingItem;
        }
    }


}
