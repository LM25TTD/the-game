using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game over action. This script controls the panel with the GameOver message
/// hiding it on start and checking if it must be active (if the player dies)
/// </summary>
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
