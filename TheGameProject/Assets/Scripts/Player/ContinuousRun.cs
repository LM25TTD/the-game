using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRun : Controller {

	// Update is called once per frame
	public override void Update () {
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
