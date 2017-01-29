using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameObject.Find ("Player")) {
			StartCoroutine (restart ());
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Destroy(other.gameObject);
	}

	IEnumerator restart() {
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
