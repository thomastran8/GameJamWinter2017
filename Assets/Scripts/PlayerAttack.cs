using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private Vector3 originalPosition;
	private bool isAttacking;
	public float maxThrowingTime;
	private float endThrowingTime;
	public float throwingSpeed;


	//timeStamp = Time.time + coolDownPeriodInSeconds;
	// Use this for initialization
	void Start () {
		originalPosition = transform.localPosition;
		isAttacking = false;
	}

	// Update is called once per frame
	void Update () {
		
		if ((Input.GetAxis ("Jump") != 0) && !isAttacking) {
			isAttacking = true;

			attack ();
		}
//		if (currentCoolDown <= 0) {
//			if (Input.GetAxis ("Jump")) {
//				attack()
//			}
//
//		} else {
//			currentCoolDown 
//		}
	}


	void attack() {
		//originalPosition = transform.position;
		StartCoroutine( stab ());
	}

	IEnumerator stab() {
		endThrowingTime = Time.time + maxThrowingTime;
		while (Time.time < endThrowingTime) {
			Debug.Log("FirstCoroutine running:" + Time.time + " " + endThrowingTime);
			transform.position = new Vector2(transform.position.x + throwingSpeed, transform.position.y);
			yield return new WaitForEndOfFrame ();
				
		}


		Debug.Log("FirstCoroutine finished:" + Time.time);
		//endThrowingTime = Time.time + maxThrowingTime;
		StartCoroutine(returnStab());

	}

	IEnumerator returnStab() {
		Debug.Log("SecondCoroutine running:" + Time.time);
		endThrowingTime = Time.time + maxThrowingTime;
		while (Time.time < endThrowingTime) {
			Debug.Log("FirstCoroutine running:" + Time.time + " " + endThrowingTime);
			transform.position = new Vector2(transform.position.x - throwingSpeed, transform.position.y);
			yield return new WaitForEndOfFrame ();

		}
		transform.localPosition = originalPosition;
		isAttacking = false;
		Debug.Log("SecondCoroutine finished:" + Time.time);
	}
}


