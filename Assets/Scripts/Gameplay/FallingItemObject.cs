using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItemObject : MonoBehaviour
{

    public Sprite sprite;
    public float gravityScale;
    public float mass;

    public float spawnWaitSeconds;
    Timer spawnDelayTimer;
    bool canBeSpawned;

    private Rigidbody2D rb;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;

        rb = GetComponent<Rigidbody2D>();
        rb.mass = mass;
        rb.gravityScale = gravityScale;

        spawnDelayTimer = gameObject.AddComponent<Timer>();
        spawnDelayTimer.Duration = spawnWaitSeconds;
        spawnDelayTimer.AddTimerFinishedListener(HandleSpawnDelayTimerFinished);
        spawnDelayTimer.Run();

    }

    private void HandleSpawnDelayTimerFinished()
    {
        canBeSpawned = true;
    }
}