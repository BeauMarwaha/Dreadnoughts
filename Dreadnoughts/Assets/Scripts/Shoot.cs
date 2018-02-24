using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject prefabBullet;
	public Transform tank;
    public Transform bulletContainer;

	void ShootBullet() {
        Transform turretTransform = tank.GetChild(1);
        Vector3 intialPosition = tank.position + new Vector3(0f, 0.273f, 0f) + turretTransform.forward * 0.59f;
		Instantiate(prefabBullet, intialPosition, turretTransform.rotation, bulletContainer);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			ShootBullet();
		}
	}
}
