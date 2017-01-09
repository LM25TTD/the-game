using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player collider detector. Must be applied to Player game object
/// to detect collisions with dangerous objects, which will decrease the 
/// player health. Each collision decreases the health by 1 point.
/// </summary>
public class PlayerColliderDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Raises the controller collider hit event. Check if the collision is with a
	/// dangerous object and, if true, decrease the health.
	/// </summary>
	/// <param name="hit">Hit.</param>
	public void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.CompareTag(Constants.TAG_DANGEROUS_OBSTACLE))
		{
			PlayerInfoManager.Instance.DecreaseHealth(1.0f);
		}
	}
}
