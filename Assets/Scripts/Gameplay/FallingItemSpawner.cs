using System.Collections.Generic;
using UnityEngine;

public class FallingItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fallingItemObjectPrefab;
    [SerializeField]
    private GameObject pickableFallingItemObjectPrefab;

    private List<GameObject> fallingItemObjects;

    private FallingItem[] fallingItems;
    private PickableFallingItem[] pickableFallingItems;
    
    private int numberOfRepeatedItems = 2;

    private Timer spawnDelayTimer;
    int spawnDelaySeconds = 5;

    private void Awake()
    {
        PopulateItems();
    }

    private void Start()
    {
        spawnDelayTimer = gameObject.AddComponent<Timer>();
        spawnDelayTimer.AddTimerFinishedListener(SpawnObjects);
        RunSpawnDelayTimer();
    }

    private void PopulateItems()
    {
        fallingItems = Resources.LoadAll<FallingItem>(GameConstants.FallingItemsResourcesPath);
        pickableFallingItems = Resources.LoadAll<PickableFallingItem>(GameConstants.PickableFallingItemsResourcesPath);
        fallingItemObjects = new List<GameObject>();

        InstantiateFallingItems();
        InstantiatePickableFallingItems();
    }

    private void InstantiateFallingItems()
    {
        for (int i = 0; i < fallingItems.Length; i++)
        {
            FallingItem currentFallingItem = fallingItems[i];

            for (int j = 0; j < numberOfRepeatedItems; j++)
            {
                GameObject newObject = InstantiateObject(fallingItemObjectPrefab);
                FallingItemObject currentFallingItemObject = newObject.GetComponent<FallingItemObject>();

                SetFallingItemObjectAttributes(currentFallingItemObject, currentFallingItem);

                fallingItemObjects.Add(newObject);
            }
        }
    }

    private void InstantiatePickableFallingItems()
    {
        for (int i = 0; i < pickableFallingItems.Length; i++)
        {
            PickableFallingItem currentpickableFallingItem = pickableFallingItems[i];

            for (int j = 0; j < numberOfRepeatedItems; j++)
            {
                GameObject newObject = InstantiateObject(pickableFallingItemObjectPrefab);
                PickableFallingItemObject currentPickableFallingItemObject = newObject.GetComponent<PickableFallingItemObject>();

                SetPickableFallingItemObjectAttributes(currentPickableFallingItemObject, currentpickableFallingItem);

                fallingItemObjects.Add(newObject);
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
        SetFallingItemObjectAttributes(pickableFallingItemObject, pickableFallingItem);
        pickableFallingItemObject.mass = pickableFallingItem.pickupWeight;
    }

    private GameObject InstantiateObject(GameObject prefab)
    {
        GameObject newObject = Instantiate(prefab);
        return newObject;
    }

    private void RunSpawnDelayTimer()
    {
        spawnDelayTimer.Duration = spawnDelaySeconds;
        spawnDelayTimer.Run();
    }
    
    private void SpawnObjects()
    {
        foreach (GameObject gameObject in fallingItemObjects)
        {
            if (gameObject.GetComponent<FallingItemObject>().CanBeSpawned)
            {
                gameObject.SetActive(true);
                gameObject.transform.position = new Vector3(0, 7, 0);
            }
        }

        RunSpawnDelayTimer();
    }
}
