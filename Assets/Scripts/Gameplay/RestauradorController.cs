using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestauradorController : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    private static Rigidbody2D rigid;
	
	[HideInInspector]
	public bool escalera = false;
	
	public float climbSpeed = 5f;
	
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if(escalera)
		{
			rigid.velocity = Vector2.zero;
			float inputY = Input.GetAxisRaw("Vertical"); 
			rigid.AddForce(new Vector2 (rigid.velocity.x,inputY*climbSpeed));
		}
    }

	private void OnTriggerEnter2D(Collider2D collider2D)
	{
		if (collider2D.tag == "Escalera")
		{
			escalera = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collider2D)
	{
		if (collider2D.tag == "Escalera")
		{
			escalera = false;
		}
	}
}
