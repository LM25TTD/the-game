using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to represent the player direction.
/// </summary>
public enum InputDirection {
	Top,
	Bottom,
	Left,
	Right
}

/// <summary>
/// This class is used to receive status from in-screen buttons.
/// It just return the direction of the movement to be followed
/// by the character.
/// </summary>
public class ButtonDetector : MonoBehaviour {

	private InputDirection mInputDirection = InputDirection.Bottom;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
	}

	//Public functions called by the button element
	public void LeftButtonPressed()
	{
		mInputDirection = InputDirection.Left;
	}

	//Public functions called by the button element
	public void RightButtonPressed()
	{
		mInputDirection = InputDirection.Right;
	}

	//Public functions called by the button element
	public void TopButtonPressed()
	{
		mInputDirection = InputDirection.Top;
	}

	 

	/// <summary>
	/// Detects the input direction. Functions called by Player controller to check 
	/// the input to be followed be the character
	/// </summary>
	/// <returns>The input direction.</returns>
	public InputDirection? DetectInputDirection()
	{
		InputDirection returnedDirection = mInputDirection;
		mInputDirection = InputDirection.Bottom;
		return returnedDirection;
	}
}
