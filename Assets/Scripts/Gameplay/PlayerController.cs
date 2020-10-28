using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private SpriteRenderer spriteRender;
    private static Rigidbody2D rigid;
    private bool mirada = false;

    bool canReceiveDamage = true;

    [SerializeField]
    HUD hud;

    private int lifes = 3;

    public static Rigidbody2D PlayerRigidBody
    {
        get { return rigid; }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigid.velocity = Vector2.zero;
        Move();
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        rigid.AddForce(new Vector2(inputX * speed, 0), ForceMode2D.Impulse); //agregando velocidad

        if (inputX > 0)
        {
            mirada = false;
        }
        if (inputX < 0)
        {
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

    private IEnumerator DamageAnim()
    {
        canReceiveDamage = false;
        for(int i=0; i < 10; i++)
        {
            spriteRender.color = new Color(spriteRender.color.r, spriteRender.color.g, spriteRender.color.b, 0.8f);
            yield return new WaitForSeconds(0.1f);
            spriteRender.color = new Color(spriteRender.color.r, spriteRender.color.g, spriteRender.color.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        canReceiveDamage = true;
    }

    public void TakeDamage()
    {
        if (canReceiveDamage)
        {
            lifes -= 1;
            if (lifes == 0)
            {
                Destroy(gameObject);
            }
            StartCoroutine(DamageAnim());
        }
    }
}
