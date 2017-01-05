using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    
	private Animator anim;
	private Controller mPlayerController = null;
	private string mLastAnimationPlayed;

	public float RunAnimationSpeed = 2.0f;
	public float StandAnimationSpeed = 0.5f;
	public float JumpAnimationSpeed = 2.0f;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		mPlayerController = GetComponentInParent<Controller> ();

		/*anim [AnimationConstants.ANIM_RUN].speed = RunAnimationSpeed;
		anim [AnimationConstants.ANIM_STAND_A].speed = StandAnimationSpeed;
		anim [AnimationConstants.ANIM_RUN_JUMP_UP].speed = JumpAnimationSpeed;
		anim [AnimationConstants.ANIM_RUN_JUMP_UP].wrapMode = WrapMode.Once;
		anim [AnimationConstants.ANIM_JUMP_LOOP].wrapMode = WrapMode.Loop;*/
	}

	// Update is called once per frame
	void Update ()
	{
		if (mPlayerController.ShallMove) {
			if (mPlayerController.IsGrounded) {
				if (anim.GetInteger ("State") == 0) {
					anim.SetInteger ("State", 1);
				} else {
					anim.SetInteger ("State", 4);
				}
			} else if (mPlayerController.IsFalling) {
				if (anim.GetInteger ("State") == 2) {
					anim.SetInteger ("State", 3);
				} else {
					anim.SetInteger ("State", 5);
				}
			} else if (Input.GetButton (ControllerConstants.BUTTON_JUMP)) {
				anim.SetInteger ("State", 2);
			}
		} else {
			anim.SetInteger ("State", 0);
		}
	}
}
