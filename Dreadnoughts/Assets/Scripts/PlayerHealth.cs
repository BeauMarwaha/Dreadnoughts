using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Text PlayerHealthText;

    // audio things -- SB
    public AudioClip fireSound; // The sound to be played
    AudioSource audioSource; // The audiosource of the object

    bool ishurt;
    bool isalive;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
        isalive = true;
        // set variable for audioSource
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (ishurt == true)
        {
            //Debug.Log("Ouch");
            //Don't want all the code here since it only needs to run every once and awhile
            //Mostly here for debugging.

            ishurt = false;
        }
        else
        {
            
        }
    }

    public void TakeDamage(int damageTaken) //This is to be called from outside this script
    {
        audioSource.PlayOneShot(fireSound, 1.8f); // play hurt sound

        ishurt = true;

        currentHealth -= damageTaken;
        
        PlayerHealthText.text = "Health : " + currentHealth;

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
