using UnityEngine;

public class PickableFallingItem : FallingItem
{
    public int amountToCollect;
    [SerializeField] private float mass;

    private bool attachedToPlayer;
    private PlayerController playerController;

    public bool AttachedToPlayer
    {
        get { return attachedToPlayer; }
    }

    protected override void Start()
    {
        base.Start();
        rb.mass = mass;
        playerController = GameObject.FindGameObjectWithTag(TagName.Player.ToString()).GetComponent<PlayerController>();
    }

    private void AttachToPlayer(GameObject player)
    {
        transform.SetParent(player.transform);
        playerController.AddMass(mass);
        transform.position = player.transform.position;
        Destroy(rb);
        canBeSpawned = false;
        col.isTrigger = true;
        AudioManager.Play(AudioClipName.Lvl1PickupItem);
    }

    public void AttachToCollector(GameObject collector, Vector3 position)
    {
        playerController.RemoveMass(mass);
        transform.SetParent(collector.transform);
        transform.position = position;
        Destroy(col);
        AudioManager.Play(AudioClipName.Lvl1LeaveItem);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.tag.Equals(TagName.Player.ToString()) && !attachedToPlayer)
        {
            attachedToPlayer = true;
            AttachToPlayer(collision.gameObject);
        }
    }
}