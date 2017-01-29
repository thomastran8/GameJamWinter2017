using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.tag);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
