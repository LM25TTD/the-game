using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputDirection {
	Top,
	Bottom,
	Left,
	Right
}

public class ButtonDetector : MonoBehaviour {

	private InputDirection mInputDirection = InputDirection.Bottom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	public void LeftButtonPressed()
	{
		mInputDirection = InputDirection.Left;
	}

	public void RightButtonPressed()
	{
		mInputDirection = InputDirection.Right;
	}

	public void TopButtonPressed()
	{
		mInputDirection = InputDirection.Top;
	}

	public InputDirection? DetectInputDirection()
	{
		InputDirection returnedDirection = mInputDirection;
		mInputDirection = InputDirection.Bottom;
		return returnedDirection;
	}
}
