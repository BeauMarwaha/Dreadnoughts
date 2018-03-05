using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    bool ishurt;
    bool isalive;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (ishurt == true)
        {
            Debug.Log("Ouch");
        }
        else
        {

        }

        ishurt = false;
        
    }

    void TakeDamage(int damageTaken)
    {
        ishurt = true;
        currentHealth -= damageTaken;

        if (currentHealth <= 0 && isalive == true)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        isalive = false;
        SceneManager.LoadScene(2);
        //The number refers to the scene in the build index which can change if we add more levels. Hard coding it for now to make it simple, can/should change later
    }
}
