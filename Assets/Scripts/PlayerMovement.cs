using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rb2d; //rigid body for adding velocity and force
	Animator animator; //animator to change state

	public Transform isGround; //Sends out raycast to detect ground
	private Transform knife;
	public float speed = 1; //Speed to move horizontally
	public bool canJump = false;
	public float JumpForce; //Force of jump

	public bool isFacingRight;

	bool isGrounded = false; 

	private float movex; //Movement speed in x direction

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		knife = this.gameObject.transform.GetChild(0);
		isFacingRight = true;
	}

	void Update() {
		transform.position = transform.position + Vector3.zero;
		transform.rotation = (Quaternion.identity);
	}

	// Update is called once per frame
	void FixedUpdate () {
		movex = Input.GetAxis ("Horizontal");
		rb2d.velocity = new Vector2(movex * speed, rb2d.velocity.y);
	
		knifePosition ();//rotates knife if needed
		jump (); //Checks if should jump or not
		setAnimations ();//Plays correct animation


//		Debug.DrawLine(isGround.position, new Vector3 (isGround.position.x, -.5f,0), Color.red);
//		Debug.Log (isGrounded);


	}

	void setAnimations() {
		if (movex == 0) {
			animator.SetBool ("isIdle", true);
		} else {
			animator.SetBool ("isIdle", false);
			animator.SetFloat("xvelocity",rb2d.velocity.x);
		}
	}

	void jump() {

		isGrounded = Physics2D.Raycast(isGround.position, -Vector2.up, 0.2f);
		if (isGrounded && (Input.GetAxis ("Jump") != 0)) {
			rb2d.AddForce (new Vector2 (0, JumpForce));
		}
	}

	void knifePosition() {
		if (rb2d.velocity.x < 0 && isFacingRight) {
			//rotate knife
			knife.Rotate(Vector3.forward * -180);
			isFacingRight = false;
			knife.transform.position = knife.transform.position + new Vector3(-.64f, 0, 0);
		}

		if (rb2d.velocity.x > 0 && !isFacingRight) {
			isFacingRight = true;
			knife.Rotate(Vector3.forward * -180);
			knife.transform.position = knife.transform.position + new Vector3(.64f, 0, 0);
		}
	}
}
