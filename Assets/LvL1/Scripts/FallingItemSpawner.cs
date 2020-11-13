using System.Collections.Generic;
using UnityEngine;

public class FallingItemSpawner : MonoBehaviour
{
    [Header("Pool Settings")]
    [SerializeField] private GameObject[] fallingItems;
    [SerializeField] private int itemPoolSize;
    private List<GameObject> fallingItemsPool;

    [Header("Spawn Settings")]
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private int spawnDelaySecondsMin;
    [SerializeField] private int spawnDelaySecondsMax;
    [SerializeField] private int minObjectsToSpawn;
    [SerializeField] private int maxObjectsToSpawn;
    private CountdownTimer spawnDelayTimer;

    private List<string> completedItems;

    private void Awake()
    {
        fallingItemsPool = new List<GameObject>();
        completedItems = new List<string>();
        InstantiatePool();
    }

    private void Start()
    {
        spawnDelayTimer = gameObject.AddComponent<CountdownTimer>();
        spawnDelayTimer.AddTimerFinishedListener(SpawnObjects);
        RunSpawnDelayTimer();
    }

    private void InstantiatePool()
    {
        for (int i = 0; i < fallingItems.Length; i++)
        {
            for (int j = 0; j < itemPoolSize; j++)
            {
                GameObject newObject = Instantiate(fallingItems[i], spawnPositions[0].position, Quaternion.identity, transform);
                newObject.name = fallingItems[i].name;
                Vector3 euler = newObject.transform.eulerAngles;
                euler.z = Random.Range(0.0f, 360.0f);
                newObject.transform.eulerAngles = euler;
                fallingItemsPool.Add(newObject);
            }
        }
    }

    private void RunSpawnDelayTimer()
    {
        spawnDelayTimer.Duration = Random.Range(spawnDelaySecondsMin, spawnDelaySecondsMax);
        spawnDelayTimer.Run();
    }
    
    private void SpawnObjects()
    {
        int randonNumberObjects2Spawn = Random.Range(minObjectsToSpawn, maxObjectsToSpawn);
       
        for (int i = 0; i < randonNumberObjects2Spawn; i++)
        {
            Vector3 spawnPosition = spawnPositions[i].position;

            int attempts = 0;
            GameObject object2Spawn;
            do
            {
                int randonNumberObjectIndex = Random.Range(0, fallingItemsPool.Count);
                object2Spawn = fallingItemsPool[randonNumberObjectIndex];
                attempts++;
            }
            while ((completedItems.Contains(object2Spawn.name) || object2Spawn.activeSelf) && attempts < 20);

            if(attempts >= 20)
            {
                continue;
            }

            if (object2Spawn.GetComponent<FallingItem>().CanBeSpawned)
            {
                object2Spawn.SetActive(true);
                object2Spawn.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
            }
        }

        RunSpawnDelayTimer();
    }

    public void RemoveItemFromPool(string name)
    {
        completedItems.Add(name);
    }
}
