using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed;
    private Transform playerTf;

	// Use this for initialization
	void Start () {
        playerTf = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (playerTf.position.x >= 0)
            transform.Translate(Vector3.right * Time.deltaTime);
        else
            transform.Translate(Vector3.left * Time.deltaTime);
    }
}
