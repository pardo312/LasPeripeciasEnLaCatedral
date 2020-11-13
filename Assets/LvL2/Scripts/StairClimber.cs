using UnityEngine;

public class StairClimber : PlayerController
{
    [SerializeField]
	private float climbSpeed;

	private bool isClimbing = false;
	private float initialGravityScale;
	private Animator animator;

	protected override void Start()
    {
		base.Start();
		initialGravityScale = rigidBody.gravityScale;
		animator = GetComponent<Animator>();
	}

    protected override void CheckInput()
    {
        base.CheckInput();
		if (isClimbing)
		{
			velocity.y = Input.GetAxisRaw(AxisName.Vertical.ToString()) * climbSpeed;
		}

		animator.SetBool(Lvl2PlayerAnimStates.Walking.ToString(), Input.GetButton(AxisName.Horizontal.ToString()));
	}

    private void OnTriggerStay2D(Collider2D collider2D)
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
