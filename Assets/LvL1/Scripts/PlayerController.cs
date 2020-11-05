using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool lookingLeft = false;
    protected Vector2 velocity = Vector2.zero;
    
    protected SpriteRenderer spriteRender;
    protected static Rigidbody2D rigidBody;
    
    [SerializeField]
    HUD hud;
    private bool canReceiveDamage = true;
    private int lifes = 3;

    public static Rigidbody2D PlayerRigidBody
    {
        get { return rigidBody; }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        Move();
        Flip();
    }
    protected virtual void CheckInput()
    {
        velocity = Vector3.zero;
        velocity.x = Input.GetAxisRaw(AxisName.Horizontal.ToString()) * speed;
    }


    private void Move()
    {
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(velocity, ForceMode2D.Impulse);
    }
	
	private void Flip()
    {

        if (velocity.x < 0)
        {
            lookingLeft = true;
        }
        if (velocity.x > 0)
        {
            lookingLeft = false;
        }

        if (!lookingLeft ? spriteRender.flipX : !spriteRender.flipX)
        { 
            spriteRender.flipX = lookingLeft;
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
