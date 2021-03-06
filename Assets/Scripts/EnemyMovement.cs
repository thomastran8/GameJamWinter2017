﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float movespeed;
	public float climbspeed;
	public float climbDetectDistance;
	public GameObject rangeAttackObject;
	private SpriteRenderer rangeSprRend;
	private Transform playerTf;
	private Rigidbody2D rb;
	private bool facingRight;
	private SpriteRenderer sprRend;
	private bool isActivated;



	private bool celebrating = false;
	// Use this for initialization
	void Start () {
		playerTf = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
		facingRight = true;
		sprRend = GetComponent<SpriteRenderer>();
		if (rangeAttackObject)
			rangeSprRend = rangeAttackObject.GetComponent<SpriteRenderer>();
		isActivated = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{

		if (!GameObject.Find ("Player") && !celebrating) {
			celebrating = true;
			StartCoroutine (celebrate());
		}
		if (!isActivated)
			return;

		if (playerTf == null)
			return;

		float positionDifference = playerTf.position.x - transform.position.x;

		if (positionDifference >= 0)
		{
			if (facingRight == false)
			{
				flip();
			}

			transform.Translate(Vector3.right * movespeed * Time.deltaTime, Space.World);
		}
		else
		{
			if (facingRight == true)
			{
				flip();
			}

			transform.Translate(Vector3.left * movespeed * Time.deltaTime, Space.World);
		}

		if (facingRight)
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, climbDetectDistance);
			Debug.DrawRay(transform.position, Vector3.right * climbDetectDistance, Color.green);

			if (hit.collider != null && hit.collider.gameObject.CompareTag("Obstacle"))
			{
				rb.AddForce(new Vector2(2.0f, climbspeed));
			}
		}
		else
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, climbDetectDistance);
			Debug.DrawRay(transform.position, Vector3.left * climbDetectDistance, Color.green);

			if (hit.collider != null && hit.collider.gameObject.CompareTag("Obstacle"))
			{
				rb.AddForce(new Vector2(-2.0f, climbspeed));
			}
		}
	}

	private void flip()
	{
		sprRend.flipX = !sprRend.flipX;
		facingRight = !facingRight;
		if (rangeAttackObject)
		{
			rangeSprRend.flipX = !rangeSprRend.flipX;
			rangeSprRend.transform.localPosition = new Vector3(rangeSprRend.transform.localPosition.x * -1, rangeSprRend.transform.localPosition.y, rangeSprRend.transform.localPosition.z);
		}
	}

	public void setFollow(bool activeState)
	{
		isActivated = activeState;
	}

	IEnumerator celebrate(){

		while (true) {
			rb.AddForce (new Vector2 (2.0f, climbspeed* 6 * Random.value));
			yield return new WaitForSeconds (.5f);
		}
	}
}