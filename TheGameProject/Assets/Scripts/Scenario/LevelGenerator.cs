using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject ScenarioDefault = null;
	public GameObject PreviousObject = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider collider)
	{
		Vector3 newPosition = transform.position;
		newPosition.z += 200;
		if (collider.CompareTag ("Player")) {
			GameObject newPath = Instantiate (ScenarioDefault, newPosition, transform.rotation);
			LevelGenerator newPathLevelGenerator = newPath.GetComponent<LevelGenerator> ();
			if (newPathLevelGenerator != null) {
				newPathLevelGenerator.PreviousObject = gameObject;
			}
			if (PreviousObject != null) {
				Destroy (PreviousObject);
			}
		}
	}

}
