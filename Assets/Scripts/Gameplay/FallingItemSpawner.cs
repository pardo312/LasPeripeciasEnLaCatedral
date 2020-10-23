using System.Collections.Generic;
using UnityEngine;

public class FallingItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fallingItemObjectPrefab;
    [SerializeField]
    private GameObject pickableFallingItemObjectPrefab;

    private GameObject[] fallingItemObjects;

    private FallingItem[] fallingItems;
    private PickableFallingItem[] pickableFallingItems;
    

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
        fallingItems = Resources.LoadAll(GameConstants.FallingItemsResourcesPath, typeof(FallingItem)) as FallingItem[];
        pickableFallingItems = Resources.LoadAll(GameConstants.PickableFallingItemsResourcesPath, typeof(FallingItem)) as PickableFallingItem[];

        fallingItemObjects = new GameObject[(fallingItems.Length + pickableFallingItems.Length) * numberOfRepeatedItems];

        for (int i = 0; i < pickableFallingItems.Length; i++)
        {
            for(int j = 0; j < numberOfRepeatedItems; j++)
            {
                GameObject currentObject = Instantiate(fallingItemObjectPrefab);
                currentObject.SetActive(false);
                FallingItemObject currentFallingItemObject = currentObject.GetComponent<FallingItemObject>();

                PickableFallingItem currentPickableFallingItem = pickableFallingItems[i];

                SetFallingItemObjectAttributes(currentFallingItemObject, currentPickableFallingItem);
                //currentFallingItemObject.mass = currentPickableFallingItem.pickupWeight;
                

                fallingItemObjects[j] = currentObject;
            }
        }
    }

    private void InstantiateFallingItems()
    {
        for (int i = 0; i < fallingItems.Length; i++)
        {
            for (int j = 0; j < numberOfRepeatedItems; j++)
            {
                GameObject currentObject = Instantiate(fallingItemObjectPrefab);
                currentObject.SetActive(false);
            }
        }
    }

    private void SetFallingItemObjectAttributes(FallingItemObject fallingItemObject, FallingItem fallingItem)
    {
        fallingItemObject.name = fallingItem.name;
        fallingItemObject.tag = fallingItem.name;
        fallingItemObject.sprite = fallingItem.sprite;
        fallingItemObject.gravityScale = fallingItem.fallingSpeed;
        fallingItemObject.spawnWaitSeconds = fallingItem.spawnWaitSeconds;
    }

    private void SetPickableFallingItemObjectAttributes(PickableFallingItemObject pickableFallingItemObject, PickableFallingItem pickableFallingItem)
    {
        pickableFallingItemObject.mass = pickableFallingItem.pickupWeight;
    }

    private void InstantiateObject(GameObject prefab)
    {
        GameObject currentObject = Instantiate(prefab);
        currentObject.SetActive(false);
    }
}
