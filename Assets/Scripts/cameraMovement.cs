using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {


	Vector3 playerTransform;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		playerTransform = transform.parent.gameObject.transform.position;
		offset = transform.position - playerTransform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = playerTransform + offset;
		transform.position = new Vector3 (transform.position.x, transform.position.y, -10);
	}
}
