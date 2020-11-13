using UnityEngine;

public class Palomino : MonoBehaviour
{
    [SerializeField] private GameObject palomino;
    private bool inAnimation1;
    private bool inAnimation2;

    [SerializeField] private float spawnSecondsMin;
    [SerializeField] private float spawnSecondsMax;

    [SerializeField] private float durationMin;
    [SerializeField] private float durationMax;

    private CountdownTimer spawnTimer;
    private CountdownTimer durationTimer;


    void Start()
    {
        palomino.SetActive(false);

        spawnTimer = gameObject.AddComponent<CountdownTimer>();
        spawnTimer.AddTimerFinishedListener(HandleSpawnTimerFinished);
        durationTimer = gameObject.AddComponent<CountdownTimer>();
        durationTimer.AddTimerFinishedListener(HandleDurationTimerFinished);
        RunSpawnTimer();
    }

    private void RunSpawnTimer()
    {
        spawnTimer.Duration = Random.Range(spawnSecondsMin, spawnSecondsMax);
        spawnTimer.Run();
    }

    private void HandleSpawnTimerFinished()
    {
        palomino.SetActive(true);
        inAnimation1 = true;
    }

    private void RunDurationTimer()
    {
        durationTimer.Duration = Random.Range(durationMin, durationMax);
        durationTimer.Run();
    }

    private void HandleDurationTimerFinished()
    {
        inAnimation2 = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (inAnimation1)
        {
            palomino.transform.position = Vector3.Lerp(palomino.transform.position, Vector3.zero, Time.deltaTime);

            if (palomino.transform.position.magnitude <= 0.01f)
            {
                inAnimation1 = false;
                RunDurationTimer();
            }
        }

        if (inAnimation2)
        {
            palomino.transform.position = Vector3.Lerp(palomino.transform.position, new Vector3(0, 10, 0), Time.deltaTime);

            if (palomino.transform.position.y >= 9.9f)
            {
                inAnimation2 = false;
                palomino.SetActive(false);
                RunSpawnTimer();
            }
        }
    }
}
