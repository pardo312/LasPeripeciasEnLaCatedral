using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Lvl1HUD hud;

    float colliderHalfWidth;
    float colliderHalfHeight;

    private BoxCollider2D boxCollider;

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
        PickableFallingItem objectScript = collisionObject.GetComponent<PickableFallingItem>();
        if (objectScript != null && objectScript.AttachedToPlayer)
        {
            hud.CollectItem(collisionObject.name);
            objectScript.AttachToCollector(gameObject, GetRandomColliderPosition());
        }
    }
}
