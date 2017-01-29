using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {
    public int damageDealt;
	AudioSource aud;
	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
			
			aud.Play();
            other.GetComponent<Health>().takeDamage(damageDealt);
        }
    }
}
