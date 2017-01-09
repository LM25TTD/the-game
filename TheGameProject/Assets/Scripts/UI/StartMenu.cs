using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the StartMenu, loading the main scene or quiting the application.
/// </summary>
public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPlayPressed(){
		SceneManager.LoadScene (Constants.SCENE_BASE_NAME);
	}

	public void OnExitPressed(){
		Application.Quit ();
	}
}
