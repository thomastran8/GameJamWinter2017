using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour {


	private int isMovingUp = 1;
	public float speed = .3f;
	public float floatHeight = 4f;

	private Vector3 originalPosition;
	// Use this for initialization

	void Start () {
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > originalPosition.y + floatHeight) {
			isMovingUp = -1;
		}

		if (transform.position.y < originalPosition.y) {
			isMovingUp = 1;
		}

		Debug.Log ("original y: " + originalPosition.y + " current pos:" + transform.position.y);

		transform.position = new Vector3 (transform.position.x, transform.position.y + (speed * isMovingUp), transform.position.z);
	}
}
