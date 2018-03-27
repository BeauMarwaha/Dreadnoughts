using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject prefabBullet;
	public Transform tank;
    public Transform turret;
    public Transform bulletContainer;
    public int shotTimer = 180;
    public bool reloading = false;

    // Audio things -- SB
    public AudioClip fireSound; // The sound to be played
    AudioSource audioSource; // The audiosource of the object

    private void Start()
    {
        // set variable for audioSource
        audioSource = GetComponent<AudioSource>();
    }

    void ShootBullet() {
        // MODIFIED FOR NEW STARTING POSITION AND BULLET-SPAWN FIX -- Stuart Burton
        //Vector3 intialPosition = tank.position + new Vector3(0.0f, 0.25f, 0.0f);
        Vector3 intialPosition = turret.position + new Vector3(0.0f, 0.0f, 0.0f);
		Instantiate(prefabBullet, intialPosition, turret.rotation, bulletContainer);
    }

	void Update () {
        // check for whether the tank has reloaded or not -- Stuart Burton
        if (Input.GetKeyDown(KeyCode.Space) == true && reloading == false) {
			ShootBullet();
            audioSource.PlayOneShot(fireSound, 1.6f); // play firing audio
            // tank has fired and must reload -- Stuart Burton
            reloading = true;
		}
        else if (reloading == true)
        {
            // decrement shotTimer -- Stuart Burton
            shotTimer--;
            if (shotTimer <= 0)
            {
                // and if the reload is done, allow the tank to fire again -- Stuart Burton
                shotTimer = 180;
                reloading = false;
            }
        }
	}
}
