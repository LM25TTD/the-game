using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBooster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider collider)
	{
		if(collider.CompareTag(Constants.TAG_PLAYER)){
			PlayerInfoManager.Instance.IncreaseHealth (2.0f);
			Destroy(gameObject);
		}
	}
}
