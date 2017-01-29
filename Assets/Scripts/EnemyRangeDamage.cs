using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeDamage : MonoBehaviour {
    public int rangeDamage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().takeDamage(rangeDamage);
        }
    }
}
