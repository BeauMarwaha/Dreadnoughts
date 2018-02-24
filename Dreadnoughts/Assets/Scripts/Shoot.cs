using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject prefabBullet;
	public GameObject tank;

	void ShootBullet() {
		Instantiate(prefabBullet,(tank.transform.position + new Vector3(0.0f,0.273f,0.0f) + (tank.transform.forward*0.59f)), Quaternion.identity);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			ShootBullet();
		}
	}
}
