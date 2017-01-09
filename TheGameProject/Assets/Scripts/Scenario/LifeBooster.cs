using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Life booster handler. This class implements the behavior of the LifeBooster 
/// game object.
/// </summary>
public class LifeBooster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Raises the trigger enter event. Always when the Player collides with 
	/// the LifeBooster, the health shall be increased by 2 points.
	/// </summary>
	/// <param name="collider">Collider.</param>
	public void OnTriggerEnter(Collider collider)
	{
		if(collider.CompareTag(Constants.TAG_PLAYER)){
			PlayerInfoManager.Instance.IncreaseHealth (2.0f);
			Destroy(gameObject);
		}
	}
}
