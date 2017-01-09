using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is the main script that handles the player controller.
/// It applies movements, gravity, jumping and updates the score.
/// </summary>
public class Controller : MonoBehaviour
{
	public float Speed = 6.0f;
	public float JumpSpeed = 8.0f;
	public float Gravity = 100.0f;
	public float RotateSpeed = 60.0f;
	public bool ShallMove = false;
	public bool IsGrounded = false;
	public bool IsFreeFloating = false;
	public bool IsFalling = false;

	protected Vector3 mMoveDirection = Vector3.zero;
	protected CharacterController mController = null;
	protected ButtonDetector mInputDetector = null;

	// Use this for initialization
	public void Start ()
	{
		mController = GetComponent<CharacterController> ();
		mInputDetector = GetComponent<ButtonDetector> ();
	}
	
	// Using the FixedUpdate to have a more consistent movement
	// due to fixed delta time between calls.
	public virtual void FixedUpdate ()
	{
		IsFreeFloating = mController.collisionFlags == CollisionFlags.None;
		IsGrounded = (mController.collisionFlags & CollisionFlags.Below) != 0;
		IsFalling = mController.velocity.y < -1;

		if (mController != null && ShallMove) {
			if (IsGrounded) {
				float zDirection = Speed * Time.deltaTime;
				mMoveDirection = new Vector3 (0, 0, zDirection);
				mMoveDirection = transform.TransformDirection (mMoveDirection);
				mMoveDirection *= Speed;

				InputDirection? inputDirection = mInputDetector.DetectInputDirection ();

				int rotateDirection = inputDirection == InputDirection.Right ? 1 
					: inputDirection == InputDirection.Left  ? -1 : 0;
				float rotateFactor = RotateSpeed * Time.deltaTime * rotateDirection;
				transform.Rotate (0, rotateFactor, 0);

				if (inputDirection == InputDirection.Top) {
					mMoveDirection.y = JumpSpeed;
				}
			}

			//Apply gravity
			mMoveDirection.y -= Gravity * Time.deltaTime;
			mController.Move (mMoveDirection * Time.deltaTime);

			PlayerInfoManager.Instance.IncreaseScore (2.0f);
		}
	}

	//Using update just to check the die state
	void Update()
	{
		if (PlayerInfoManager.Instance.GetHealth() == 0.0f) {
			ShallMove = false;
		}
	}
}
