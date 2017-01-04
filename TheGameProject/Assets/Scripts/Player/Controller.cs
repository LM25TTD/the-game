using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public const string KEY_LEFT = "left";
	public const string KEY_RIGHT = "right";
	public const string BUTTON_JUMP = "Jump";

	public float Speed = 6.0f;
	public float JumpSpeed = 8.0f;
	public float Gravity = 100.0f;
	public float RotateSpeed = 60.0f;
	public bool ShallMove = false;

	private Vector3 mMoveDirection = Vector3.zero;
	private CharacterController mController = null;

	// Use this for initialization
	void Start ()
	{
		mController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (mController != null && ShallMove) {
			//Workaround to avoid isGrounded always false
			mController.Move (mMoveDirection * Time.deltaTime);
			if (mController.isGrounded) {
				float zDirection = Speed * Time.deltaTime;
				mMoveDirection = new Vector3 (0, 0, zDirection);
				mMoveDirection = transform.TransformDirection (mMoveDirection);
				mMoveDirection *= Speed;

				int rotateDirection = Input.GetKey (KEY_RIGHT) ? 1 : Input.GetKey (KEY_LEFT) ? -1 : 0;
				float rotateFactor = RotateSpeed * Time.deltaTime * rotateDirection;
				transform.Rotate (0, rotateFactor, 0);

				if (Input.GetButton (BUTTON_JUMP)) {
					mMoveDirection.y = JumpSpeed;
				}
			}
			mMoveDirection.y -= Gravity * Time.deltaTime;
			mController.Move (mMoveDirection * Time.deltaTime);
		}
	}
}
