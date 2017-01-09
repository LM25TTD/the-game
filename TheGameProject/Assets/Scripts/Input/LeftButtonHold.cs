using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public GameObject Player;

	bool _pressed = false;
	public void OnPointerDown(PointerEventData eventData)
	{
		_pressed = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_pressed = false;
	}

	void Update()
	{
		if (!_pressed) 
			return;
		ButtonDetector bDetector = Player.GetComponent<ButtonDetector> ();
		bDetector.LeftButtonPressed ();
	}
}
