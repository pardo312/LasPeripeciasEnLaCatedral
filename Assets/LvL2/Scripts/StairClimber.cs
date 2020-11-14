using UnityEngine;

public class StairClimber : PlayerController
{
    [SerializeField]
	private float climbSpeed;

	private bool isClimbing = false;
	[HideInInspector]public bool canMove = true;
	private float initialGravityScale;
	private Animator animator;
	private bool initSound;

	protected override void Start()
    {
		base.Start();
		initialGravityScale = rigidBody.gravityScale;
		animator = GetComponent<Animator>();
	}

    protected override void CheckInput()
    {
		if(canMove)
		{
			
			SoundFXManager sfxManager = GameObject.Find("SoundFXManager").GetComponent<SoundFXManager>();
			base.CheckInput();
			if (isClimbing)
			{
				velocity.y = Input.GetAxisRaw(AxisName.Vertical.ToString()) * climbSpeed;
			}
			if(velocity.x != 0){
				if(!initSound)
				{
					sfxManager.Play("Walk");
					initSound=true;
				}
			}
			else{
				initSound=false;	
				sfxManager.StopPlaying("Walk");
			}
			animator.SetBool(Lvl2PlayerAnimStates.Walking.ToString(), Input.GetButton(AxisName.Horizontal.ToString()));
		}
	}
	public void stopMovement(){
		velocity = Vector2.zero;
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
