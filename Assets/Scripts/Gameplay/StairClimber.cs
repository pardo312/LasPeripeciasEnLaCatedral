using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairClimber : PlayerController
{
    [SerializeField]
	private float climbSpeed;

	private bool isClimbing = false;
	private float initialGravityScale;

    protected override void Start()
    {
		base.Start();
		initialGravityScale = rigidBody.gravityScale;
	}

    protected override void CheckInput()
    {
        base.CheckInput();
		if (isClimbing)
		{
			velocity.y = Input.GetAxisRaw(AxisName.Vertical.ToString()) * climbSpeed;
		}
	}

    private void OnTriggerEnter2D(Collider2D collider2D)
	{
		if (collider2D.tag == CustomTag.Stair.ToString())
		{
			isClimbing = true;
			rigidBody.gravityScale = 0;
		}
	}

	private void OnTriggerExit2D(Collider2D collider2D)
	{
		if (collider2D.tag == CustomTag.Stair.ToString())
		{
			isClimbing = false;
			rigidBody.gravityScale = initialGravityScale;
		}
	}
}
