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

    public bool CanBeSpawned
    {
        get { return canBeSpawned; }
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        spawnDelayTimer = gameObject.AddComponent<Timer>();
        spawnDelayTimer.Duration = spawnWaitSeconds;
        spawnDelayTimer.AddTimerFinishedListener(HandleSpawnDelayTimerFinished);
        spawnDelayTimer.Run();

    }

    private void HandleSpawnDelayTimerFinished()
    {
        canBeSpawned = true;
        GetComponent<SpriteRenderer>().sprite = sprite;
        rb.gravityScale = gravityScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            gameObject.SetActive(false);
        }
    }
}