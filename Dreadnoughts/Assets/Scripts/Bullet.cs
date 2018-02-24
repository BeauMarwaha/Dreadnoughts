using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Vector3 nVector;

	void DestroyObjectDelayed()
	{
		Destroy (this.gameObject, 5);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			Destroy (this.gameObject);
		}
	}


	// Update is called once per frame
	void Update () {
		nVector = Vector3.Normalize (this.transform.position);
		nVector.y = 0.0f;
		this.transform.position += (nVector*0.1f);
		DestroyObjectDelayed ();
	}
}
