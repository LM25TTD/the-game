using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    
	private Animation anim;
	private CharacterController mCharController = null;
	private Controller mPlayerController = null;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animation> ();
		mCharController = GetComponentInParent<CharacterController> ();
		mPlayerController = GetComponentInParent<Controller> ();

		anim ["Comp|Run"].speed = 2.0f;
		anim ["Comp|StandA"].speed = 0.5f;
		anim ["Comp|RunJumpUp"].speed = 2.0f;
	}

	// Update is called once per frame
	void Update ()
	{
		if (mPlayerController.ShallMove) {
			if (mCharController.isGrounded) {
				anim.Stop ("Comp|RunJumpUp");
				anim.Play ("Comp|Run");
			} else {
				anim.Stop ("Comp|Run");
				anim.Play ("Comp|RunJumpUp");
			}
		} else {
			anim.Play ("Comp|StandA");	
		}
	}
}
