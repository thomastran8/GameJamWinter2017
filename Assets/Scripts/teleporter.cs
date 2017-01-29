using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour {
	Collider2D otherObject;
	public Transform exit;
	private bool isCharging = false;
	public float chargingTime;
	private float teleportTime;
	// Use this for initialization
	void Start () {
		
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" || other.tag == "Enemy") {
			if (!isCharging) {
				isCharging = true;
				teleportTime = Time.time + chargingTime;
				otherObject = other;
			}
		}
	}
		
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player" || other.tag == "Enemy") {
			isCharging = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + Vector3.zero;
		if (Time.time >= teleportTime && isCharging) {
			otherObject.transform.position = exit.position + new Vector3 (0, .1f, 0);

		}

		//Debug.Log ("Charging. Time left:" + (Time.time) + " " + teleportTime);

	}
}
