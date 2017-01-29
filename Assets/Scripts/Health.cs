﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int maxHealth;
    private int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        checkHealth();
    }

    private void checkHealth()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
