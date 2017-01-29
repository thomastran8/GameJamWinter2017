using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour {
    public int maxHealth;
    private int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}

    void Update()
    {

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
			if (tag == "Player") {
				StartCoroutine (restart ());
			}
        }
    }

	IEnumerator restart() {
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
