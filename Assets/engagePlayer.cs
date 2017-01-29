using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engagePlayer : MonoBehaviour {
    private EnemyMovement enemyMov;

	// Use this for initialization
	void Start () {
        enemyMov = GetComponentInParent<EnemyMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyMov.setFollow(true);
        }
    }
}
