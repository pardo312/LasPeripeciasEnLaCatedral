using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableFallingItemObject : FallingItemObject
{
    public float mass;
    private bool attachedToPlayer;
    [SerializeField]
    Transform playerReference;

    public bool AttachedToPlayer
    {
        get { return attachedToPlayer; }
    }

    protected override void Start()
    {
        base.Start();
        rb.mass = mass;
    }

    private void AttachToPlayer(GameObject player)
    {
        gameObject.transform.SetParent(player.transform);
        PlayerController.PlayerRigidBody.mass += mass;
        Destroy(rb);
        canBeSpawned = false;
        circleCollider.isTrigger = true;
    }

    public void AttachToCollector(GameObject collector, Vector3 position)
    {
        PlayerController.PlayerRigidBody.mass -= mass;
        transform.SetParent(collector.transform);
        transform.position = position;
        Destroy(circleCollider);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.tag.Equals("Player") && !attachedToPlayer)
        {
            attachedToPlayer = true;
            AttachToPlayer(collision.gameObject);
        }
    }
}