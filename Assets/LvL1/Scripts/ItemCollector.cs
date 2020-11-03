using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    float colliderHalfWidth;
    float colliderHalfHeight;
    [SerializeField]
    private HUD hud;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        colliderHalfWidth = boxCollider.size.x / 2;
        colliderHalfHeight = boxCollider.size.y / 2;
    }

    private Vector3 GetRandomColliderPosition()
    {
        Vector3 objectPosition = transform.position;

        return new Vector3(
         Random.Range(objectPosition.x - colliderHalfWidth, objectPosition.x + colliderHalfWidth),
         Random.Range(objectPosition.y, objectPosition.y + colliderHalfHeight),
         0
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        PickableFallingItemObject objectScript = collisionObject.GetComponent<PickableFallingItemObject>();
        if (LayerMask.LayerToName(collisionObject.layer).Equals("PickableItem") && objectScript.AttachedToPlayer)
        {
            hud.CollectItem(collisionObject.name);
            objectScript.AttachToCollector(gameObject, GetRandomColliderPosition());
        }
    }
}
