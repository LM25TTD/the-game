using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    
	private Animation anim;
	private Controller mPlayerController = null;
	private string mLastAnimationPlayed;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animation> ();
		mPlayerController = GetComponentInParent<Controller> ();

		anim ["Comp|Run"].speed = 2.0f;
		anim ["Comp|StandA"].speed = 0.5f;
		anim ["Comp|RunJumpUp"].speed = 2.0f;

		anim ["Comp|JumpLoop"].wrapMode = WrapMode.Loop;
	}

	// Update is called once per frame
	void Update ()
	{
		if (mPlayerController.ShallMove) {
			if (mPlayerController.IsGrounded) {
				StopAllOtherAndRunAnimation (anim, "Comp|Run");
			} else if (Input.GetButton ("Jump")) {
				StopAllOtherAndRunAnimation (anim, "Comp|RunJumpUp");
			} else if (mPlayerController.IsFreeFloating) {
				StopAllOtherAndRunAnimation (anim, "Comp|JumpLoop");
			}
		} else {
			StopAllOtherAndRunAnimation (anim, "Comp|StandA");
		}
	}


	private void StopAllOtherAndRunAnimation (Animation anim, string toBePlayed)
	{
		if (!string.IsNullOrEmpty (mLastAnimationPlayed) && mLastAnimationPlayed != toBePlayed) {
			anim.Stop (mLastAnimationPlayed);
		}
		anim.Play (toBePlayed);
		mLastAnimationPlayed = toBePlayed;
	}
}
