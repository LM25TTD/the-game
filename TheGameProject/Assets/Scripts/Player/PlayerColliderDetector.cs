using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.CompareTag("DangerousObstacle"))
		{
			PlayerInfoManager.Instance.DecreaseHealth(1.0f);
		}
	}
}
