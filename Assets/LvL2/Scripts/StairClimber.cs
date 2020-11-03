using UnityEngine;

public class StairClimber : PlayerController
{
    [SerializeField]
	private float climbSpeed;

	private bool isClimbing = false;
	private float initialGravityScale;

	protected Animator animator;
	private enum AnimatorStates
	{
		Walking
	}

	protected override void Start()
    {
		base.Start();
		animator = GetComponent<Animator>();
		initialGravityScale = rigidBody.gravityScale;
	}

    protected override void CheckInput()
    {
        base.CheckInput();
		if (isClimbing)
		{
			velocity.y = Input.GetAxisRaw(AxisName.Vertical.ToString()) * climbSpeed;
		}
		animator.SetBool(AnimatorStates.Walking.ToString(), Input.GetButton(AxisName.Horizontal.ToString()));
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
