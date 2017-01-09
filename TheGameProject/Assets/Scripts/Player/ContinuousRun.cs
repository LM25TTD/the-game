using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is an override of default controller,
/// just keep the player running.
/// </summary>
public class ContinuousRun : Controller {

	// Just run in infinite scenario.
	public override void FixedUpdate () {
		IsFreeFloating = mController.collisionFlags == CollisionFlags.None;
		IsGrounded = (mController.collisionFlags & CollisionFlags.Below) != 0;
		IsFalling = mController.velocity.y < -1;

		if (mController != null && ShallMove) {
			float zDirection = Speed * Time.deltaTime;
			mMoveDirection = new Vector3 (0, 0, zDirection);
			mMoveDirection = transform.TransformDirection (mMoveDirection);
			mMoveDirection *= Speed;

			mMoveDirection.y -= Gravity * Time.deltaTime;
			mController.Move (mMoveDirection * Time.deltaTime);
		}
	}
}
