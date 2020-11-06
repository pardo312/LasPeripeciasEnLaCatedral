using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItemObject : MonoBehaviour
{

    public Sprite sprite;
    public float gravityScale;

    public float spawnWaitSeconds;
    private CountdownTimer spawnDelayTimer;
    protected bool canBeSpawned;

    protected Rigidbody2D rb;
    protected CircleCollider2D circleCollider;

    public bool CanBeSpawned
    {
        get { return canBeSpawned; }
    }

    protected virtual void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        spawnDelayTimer = gameObject.AddComponent<CountdownTimer>();
        spawnDelayTimer.Duration = spawnWaitSeconds;
        spawnDelayTimer.AddTimerFinishedListener(HandleSpawnDelayTimerFinished);
        spawnDelayTimer.Run();

    }

    private void HandleSpawnDelayTimerFinished()
    {
        Initialize();
    }

    private void Initialize()
    {
        canBeSpawned = true;
        GetComponent<SpriteRenderer>().sprite = sprite;
        rb.gravityScale = gravityScale;
        circleCollider.isTrigger = false;
        gameObject.SetActive(false);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            gameObject.SetActive(false);
        }

        if (gameObject.tag == "FallingItem" && collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage();
            gameObject.SetActive(false);
        }
    }
}