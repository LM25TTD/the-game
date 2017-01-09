using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAction : MonoBehaviour {

	public GameObject GameOverMenu = null;

	// Use this for initialization
	void Start () {
		GameOverMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerInfoManager.Instance.GetHealth () == 0.0f) {
			GameOverMenu.SetActive (true);
		}
	}
}
