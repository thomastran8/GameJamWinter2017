using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {


	public Transform playerTransform;

	private Vector3 playerPosition;

	Vector3 offset;
	// Use this for initialization
	void Start () {
		playerPosition = playerTransform.position;
		offset = transform.position - playerPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerPosition == null)
        {
            return;
        }
		playerPosition = playerTransform.position;
		transform.position = playerPosition + offset;
		transform.position = new Vector3 (transform.position.x, transform.position.y, -10);
	}
}
