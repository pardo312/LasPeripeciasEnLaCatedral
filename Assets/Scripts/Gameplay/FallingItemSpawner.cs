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
    private static PickableFallingItem[] pickableFallingItems;

    public static PickableFallingItem[] PickableFallingItems
    {
        get { return pickableFallingItems; }
    }

    private int numberOfRepeatedItems = 8;

    private Timer spawnDelayTimer;
    int spawnDelaySeconds = 5;

    [SerializeField]
    Transform spawnPositionMin;
    [SerializeField]
    Transform spawnPositionMax;

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

            for (int j = 0; j < currentpickableFallingItem.amountToCollect; j++)
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
        GameObject newObject = Instantiate(prefab, spawnPositionMin.position, Quaternion.identity);
        return newObject;
    }

    private void RunSpawnDelayTimer()
    {
        spawnDelayTimer.Duration = spawnDelaySeconds;
        spawnDelayTimer.Run();
    }
    
    private void SpawnObjects()
    {
        int randonNumberObjects2Spawn = Random.Range(1, fallingItemObjects.Count);

        for(int i = 0; i < randonNumberObjects2Spawn; i++)
        {
            int randonNumberObjectIndex = Random.Range(0, fallingItemObjects.Count);
            GameObject object2Spawn = fallingItemObjects[randonNumberObjectIndex];
            if (object2Spawn.GetComponent<FallingItemObject>().CanBeSpawned)
            {
                object2Spawn.SetActive(true);
                float x = Random.Range(spawnPositionMin.position.x, spawnPositionMax.position.x);
                object2Spawn.transform.position = new Vector3(x, spawnPositionMin.position.y, spawnPositionMin.position.z);
            }
        }

        RunSpawnDelayTimer();
    }
}
