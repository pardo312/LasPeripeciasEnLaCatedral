using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool lookingLeft = false;
    protected Vector2 velocity = Vector2.zero;

    protected Rigidbody2D rigidBody;
    private SpriteRenderer spriteRender;

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

    public void AddMass(float mass)
    {
        rigidBody.mass += mass;
    }

    public void RemoveMass(float mass)
    {
        rigidBody.mass -= mass;
    }
}
