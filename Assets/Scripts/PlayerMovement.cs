using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rb2d; //rigid body for adding velocity and force
	Animator animator; //animator to change state

	public Transform isGround; //Sends out raycast to detect ground

	public float speed = 1; //Speed to move horizontally
	public bool canJump = false;
	public float JumpForce; //Force of jump

	bool isGrounded = false; 

	private float movex; //Movement speed in x direction

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update() {

	}
	// Update is called once per frame
	void FixedUpdate () {
		movex = Input.GetAxis ("Horizontal");
		rb2d.velocity = new Vector2(movex * speed, rb2d.velocity.y);

		jump (); //Checks if should jump or not


//		Debug.DrawLine(isGround.position, new Vector3 (isGround.position.x, -.5f,0), Color.red);
//		Debug.Log (isGrounded);


		if (movex == 0) {
			animator.SetBool ("isIdle", true);
		} else {
			animator.SetBool ("isIdle", false);
			animator.SetFloat("xvelocity",rb2d.velocity.x);
		}
	}

	void jump() {

		isGrounded = Physics2D.Raycast(isGround.position, -Vector2.up, 0.1f);
		if (isGrounded) {
			float movey = Input.GetAxis ("Vertical");
			rb2d.AddForce (new Vector2 (0, movey * JumpForce));
		}
	}
}
