using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject prefabBullet;
	public Transform tank;
<<<<<<< HEAD
    public Transform turrent;
    public Transform bulletContainer;

	void ShootBullet() {
        Vector3 intialPosition = tank.position + new Vector3(0f, 0.273f, 0f) + turrent.forward * 0.59f;
		Instantiate(prefabBullet, intialPosition, turrent.rotation, bulletContainer);
=======
    public Transform turret;
    public Transform bulletContainer;

	void ShootBullet() {
        Vector3 intialPosition = tank.position + new Vector3(0f, 0.273f, 0f) + turret.forward * 0.59f;
		Instantiate(prefabBullet, intialPosition, turret.rotation, bulletContainer);
>>>>>>> 02224defc49b1d06794a40032950f109b76f9ae5
    }

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			ShootBullet();
		}
	}
}
