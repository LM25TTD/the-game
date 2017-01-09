using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawn element. The class spawn new games objects elements into given positions.
/// </summary>
public class SpawnElement : MonoBehaviour {

	public int RandomBase = 0;
	public int RandomMax = 3;

	public GameObject SpawnedElement;
	public Transform[] Positions;

	/// <summary>
	/// Start this instance. On each start, each position have a probably chance to have a game element.
	/// </summary>
	void Start () {
		for(int i=0; i< Positions.Length; i++){
			//% chance is given by RandomBase and RandomMax
			if (Random.Range (RandomBase, RandomMax) == 0) 
			{
				GameObject element = Instantiate (SpawnedElement, Positions[i].position, Quaternion.identity);
				element.transform.parent = gameObject.transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
