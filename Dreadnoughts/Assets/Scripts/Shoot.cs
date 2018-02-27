using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject prefabBullet;
	public Transform tank;
    public Transform turrent;
    public Transform bulletContainer;

	void ShootBullet() {
        Vector3 intialPosition = tank.position + new Vector3(0f, 0.273f, 0f) + turrent.forward * 0.59f;
		Instantiate(prefabBullet, intialPosition, turrent.rotation, bulletContainer);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			ShootBullet();
		}
	}
}
