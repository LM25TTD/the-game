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
	}

	// Update is called once per frame
	void Update ()
	{
		if (mPlayerController.ShallMove) {
			if (mPlayerController.IsGrounded) {
				if (anim.GetInteger (Constants.ANIM_CONTROL) == 0) {
					anim.SetInteger (Constants.ANIM_CONTROL, 1);
				} else {
					anim.SetInteger (Constants.ANIM_CONTROL, 4);
				}
			} else if (mPlayerController.IsFalling) {
				if (anim.GetInteger (Constants.ANIM_CONTROL) == 2) {
					anim.SetInteger (Constants.ANIM_CONTROL, 3);
				} else {
					anim.SetInteger (Constants.ANIM_CONTROL, 5);
				}
			} else if (Input.GetButton (Constants.CONTROLLER_BUTTON_JUMP)) {
				anim.SetInteger (Constants.ANIM_CONTROL, 2);
			}
		} else {
			anim.SetInteger (Constants.ANIM_CONTROL, 0);
		}

		if (PlayerInfoManager.Instance.GetHealth () == 0.0f) {
			anim.SetInteger (Constants.ANIM_CONTROL, 10);
		}
	}
}
