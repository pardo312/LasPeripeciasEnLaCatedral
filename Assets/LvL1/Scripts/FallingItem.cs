using UnityEngine;

public class FallingItem : MonoBehaviour
{
    [SerializeField] private float gravityScale;
    [SerializeField] private float spawnWaitSeconds;

    private CountdownTimer spawnDelayTimer;
    protected bool canBeSpawned;

    protected Rigidbody2D rb;
    protected Collider2D col;

    public bool CanBeSpawned
    {
        get { return canBeSpawned; }
    }

    protected virtual void Start()
    {
        col = GetComponent<Collider2D>();
        col.isTrigger = true;

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
        rb.gravityScale = gravityScale;
        col.isTrigger = false;
        canBeSpawned = true;
        gameObject.SetActive(false);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(TagName.Floor.ToString()))
        {
            AudioManager.Play(AudioClipName.Lvl1StoneCrash);
            gameObject.SetActive(false);
        }
    }
}