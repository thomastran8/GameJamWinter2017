using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator nextLevel() {
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
