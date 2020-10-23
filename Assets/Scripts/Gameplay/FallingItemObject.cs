using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItemObject : MonoBehaviour
{

    public Sprite sprite;
    public float gravityScale;

    public float spawnWaitSeconds;
    private Timer spawnDelayTimer;
    private bool canBeSpawned;

    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;

        rb = GetComponent<Rigidbody2D>();
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