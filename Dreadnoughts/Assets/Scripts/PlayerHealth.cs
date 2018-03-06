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
            //Don't want all the code here since it only needs to run every once and awhile
            //Mostly here for debugging.
        }
        else
        {

        }

        ishurt = false;
        
    }

    void TakeDamage(int damageTaken) //This is to be called from outside this script
    {
        ishurt = true;
        //Death flag to make sure it only runs once

        currentHealth -= damageTaken;

        if (currentHealth <= 0 && isalive == true)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        isalive = false;
        SceneManager.LoadScene("GameOver");
    }
}
