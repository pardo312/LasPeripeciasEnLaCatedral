using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private CircleCollider2D coll2D;
    [SerializeField]private CheckIfEndLevel checkIfEndLevel;

    // Start is called before the first frame update
    void Start()
    {
        coll2D = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(GetComponent<Animator>());
            checkIfEndLevel.gotSculptures++;
            transform.SetParent(collision.gameObject.transform);
            transform.localPosition = Vector3.zero;
        }
    }
}
