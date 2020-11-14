using System.Collections;
using UnityEngine;

public class Palomino : MonoBehaviour
{
    [SerializeField] private GameObject palomino;

    [SerializeField] private float spawnSecondsMin;
    [SerializeField] private float spawnSecondsMax;

    [SerializeField] private float durationMin;
    [SerializeField] private float durationMax;

    private CountdownTimer spawnTimer;
    public CountdownTimer durationTimer;


    void Start()
    {
        spawnTimer = gameObject.AddComponent<CountdownTimer>();
        spawnTimer.AddTimerFinishedListener(HandleSpawnTimerFinished);
        durationTimer = gameObject.AddComponent<CountdownTimer>();

        palomino.GetComponent<Palomino2>().Initialize();
        palomino.SetActive(false);
        RunSpawnTimer();
    }

    public void RunSpawnTimer()
    {
        spawnTimer.Duration = Random.Range(spawnSecondsMin, spawnSecondsMax);
        spawnTimer.Run();
    }

    private void HandleSpawnTimerFinished()
    {
        palomino.SetActive(true);
    }

    public void RunDurationTimer()
    {
        durationTimer.Duration = Random.Range(durationMin, durationMax);
        durationTimer.Run();
    }

}