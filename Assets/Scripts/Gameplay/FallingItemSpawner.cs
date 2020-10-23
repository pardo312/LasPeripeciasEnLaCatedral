using System.Collections.Generic;
using UnityEngine;

public class FallingItemSpawner : MonoBehaviour
{
    

    [SerializeField]
    private GameObject fallingItemObjectPrefab;
    private PickableFallingItem[] pickableFallingItems;
    private GameObject[] fallingItemObjects;

    private int numberOfRepeatedItems = 2;

    private void Awake()
    {
        PopulateItems();
    }

    private void Start()
    {
        foreach(GameObject gameObject in fallingItemObjects)
        {
            gameObject.transform.position = new Vector3(0, 7, 0);
            gameObject.SetActive(true);
        }
    }

    private void PopulateItems()
    {
        Object[] items = Resources.LoadAll(GameConstants.PickableFallingItemsResourcesPath, typeof(FallingItem));
        pickableFallingItems = new PickableFallingItem[items.Length];
        fallingItemObjects = new GameObject[pickableFallingItems.Length * numberOfRepeatedItems];
        for (int i = 0; i < items.Length; i++)
        {
            pickableFallingItems[i] = items[i] as PickableFallingItem;

            for(int j = 0; j < numberOfRepeatedItems; j++)
            {
                GameObject currentObject = Instantiate(fallingItemObjectPrefab);
                currentObject.SetActive(false);
                FallingItemObject currentFallingItemObject = currentObject.GetComponent<FallingItemObject>();

                PickableFallingItem currentPickableFallingItem = pickableFallingItems[i];
                currentFallingItemObject.name = currentPickableFallingItem.name;
                currentFallingItemObject.tag = currentPickableFallingItem.name;
                currentFallingItemObject.sprite = currentPickableFallingItem.sprite;
                currentFallingItemObject.gravityScale = currentPickableFallingItem.fallingSpeed;
                currentFallingItemObject.mass = currentPickableFallingItem.pickupWeight;
                currentFallingItemObject.spawnWaitSeconds = currentPickableFallingItem.spawnWaitSeconds;

                fallingItemObjects[j] = currentObject;
            }
        }
    }
}
