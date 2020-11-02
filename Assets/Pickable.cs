using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private CircleCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.SetParent(collision.gameObject.transform);
            transform.localPosition = Vector3.zero;
        }
    }
}
