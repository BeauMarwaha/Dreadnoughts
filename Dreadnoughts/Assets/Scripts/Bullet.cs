﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Vector3 nVector;
    private float bulletSpeed = 5.0f;

    // Use this for initialization
    void Start()
    {
        DestroyObjectDelayed();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * bulletSpeed;
    }

    void DestroyObjectDelayed()
	{
		Destroy (this.gameObject, 5);
	}

	void OnCollisionEnter(Collision col)
	{
        // On collision destory the enemy and the bullet
		if (col.gameObject.tag == "Enemy")
		{
            Destroy(col.gameObject);
            Destroy (this.gameObject);
		}
<<<<<<< HEAD
	}
=======
    }
>>>>>>> 02224defc49b1d06794a40032950f109b76f9ae5
}
