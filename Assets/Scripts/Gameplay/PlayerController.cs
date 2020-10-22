using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private SpriteRenderer spriteRender;
	private Rigidbody2D rb2d;
	private bool mirada = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
		rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		float inputX = Input.GetAxis("Horizontal");
		rb2d.velocity = new Vector2(inputX* speed, rb2d.velocity.y); //agregando velocidad
		
		if (inputX>0) {
			mirada= false;
		}
		if (inputX<0){
			mirada = true;
		}
		Flip();//para que el personaje gire a la direccion en que se mueve
    }
	
	private void Flip(){
		if ((!mirada ? spriteRender.flipX : !spriteRender.flipX))
        { 
            spriteRender.flipX = mirada;
        }
	}
}
