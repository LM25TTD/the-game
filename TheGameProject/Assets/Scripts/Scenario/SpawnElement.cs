using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElement : MonoBehaviour {

	public int RandomBase = 0;
	public int RandomMax = 3;

	public GameObject SpawnedElement;
	public Transform[] Positions;

	// Use this for initialization
	void Start () {
		for(int i=0; i< Positions.Length; i++){
			//50% chance
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
