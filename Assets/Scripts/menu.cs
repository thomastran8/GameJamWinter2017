using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startGame(){
		SceneManager.LoadScene (2);
	}

	public void quit() {
		Application.Quit();
	}

	public void help() {
		SceneManager.LoadScene (1);
	}
}

