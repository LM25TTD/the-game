using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class must be added to button to detect the on hold action from user.
/// It uses a GameObject, the shall be the player with a ButtonDetector attached.
/// </summary>
public class RightButtonHold : ButtonHoldDetector
{
	public GameObject Player;

	/// <summary>
	/// In this case, call the method RightButton pressed
	/// To represent a pressing hold on right button.
	/// </summary>
	protected override void DoAction()
	{
		ButtonDetector bDetector = Player.GetComponent<ButtonDetector> ();
		bDetector.RightButtonPressed ();
	}
}
