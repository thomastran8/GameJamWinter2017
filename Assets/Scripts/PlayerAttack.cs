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
		
		isAttacking = false;
	}

	// Update is called once per frame
	void Update () {
		
		if ((Input.GetAxis ("Jump") != 0) && !isAttacking) {
			originalPosition = transform.localPosition;
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

		bool isFacingRight = transform.parent.GetComponent<PlayerMovement>().isFacingRight;
		if (isFacingRight) {
			StartCoroutine( stab (1));
		} else {
			StartCoroutine( stab (-1));
		}
		//originalPosition = transform.position;

	}

	IEnumerator stab(int direction) {
		endThrowingTime = Time.time + maxThrowingTime;
		while (Time.time < endThrowingTime) {
			transform.position = new Vector2(transform.position.x + (throwingSpeed * direction), transform.position.y);
			yield return new WaitForEndOfFrame ();
				
		}

	
		StartCoroutine(returnStab(direction));

	}

	IEnumerator returnStab(int direction) {
		
		endThrowingTime = Time.time + maxThrowingTime;
		while (Time.time < endThrowingTime) {
			
			transform.position = new Vector2(transform.position.x - (throwingSpeed * direction), transform.position.y);
			yield return new WaitForEndOfFrame ();

		}
		transform.localPosition = originalPosition;
		isAttacking = false;
	}
}


