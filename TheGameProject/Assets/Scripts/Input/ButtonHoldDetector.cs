using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Button hold detector. This is a base class to button hold detectors.
/// </summary>
public abstract class ButtonHoldDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	bool _pressed = false;
	public void OnPointerDown(PointerEventData eventData)
	{
		_pressed = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_pressed = false;
	}

	/// <summary>
	/// Detect the on hold state and do some action.
	/// </summary>
	void Update()
	{
		if (!_pressed)
			return;
		DoAction ();
	}

	protected abstract void DoAction ();
}
