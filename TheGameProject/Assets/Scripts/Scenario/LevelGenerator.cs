using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level generator. Generates a new piece of the scenario to keep the illusion
/// of infinite path.
/// </summary>
public class LevelGenerator : MonoBehaviour {

	public GameObject ScenarioDefault = null;
	public GameObject PreviousObject = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Raises the trigger enter event. This trigger will instantiate a new scenario
	/// on each collision.
	/// </summary>
	/// <param name="collider">Collider.</param>
	public void OnTriggerEnter(Collider collider)
	{
		Vector3 newPosition = transform.position;
		newPosition.z += 200;
		if (collider.CompareTag (Constants.TAG_PLAYER)) {
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
