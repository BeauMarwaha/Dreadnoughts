using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyShootingHandler : MonoBehaviour {

    private Transform turret; // Turret transform
    private Transform player; // Player transform
    private Quaternion targetRotation; // Ideal turret rotation
    private Transform enemyBulletContainer; // Container to hold enemy bullets
    private float cooldownTimeStamp; // Time of last fired shot
    private float cooldownTime = 5.0f; // Cooldown time between shots
    private float turnStrength = 0.5f; // Turret turning strength
    private float shootRange = 0.9999f; // Allowable range in which the turret will shoot at the player (closer to 1.0 = more precise)

    public GameObject prefabEnemyBullet; // Enemy Bullet Prefab

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Tank").transform;
        turret = GetComponentsInChildren<Transform>().First(x => x.name == "Turret");
        enemyBulletContainer = GameObject.Find("EnemyBulletContainer").transform;
    }
	
	// Update is called once per frame
	void Update () {
        RotateTurretTowardsPlayer();
        FireTurret();
    }

    /// <summary>
    /// Rotates the turret towards the player smoothly
    /// </summary>
    void RotateTurretTowardsPlayer()
    {
        targetRotation = Quaternion.LookRotation(player.position - turret.position);
        targetRotation *= Quaternion.Euler(0, -90, 0); //REMOVE ME WHEN MODEL GETS FIXED
        float turnDeg = Mathf.Min(turnStrength * Time.deltaTime, 1);
        turret.rotation = Quaternion.Lerp(turret.rotation, targetRotation, turnDeg);
    }

    /// <summary>
    /// Fires the 
    /// </summary>
    void FireTurret()
    {
        // If the turret is lined up on the player and the shot is off cooldown
        if(Mathf.Abs(Quaternion.Dot(targetRotation, turret.rotation)) > shootRange && cooldownTimeStamp <= Time.time)
        {
            // Shoot a bullet at the player
            Vector3 intialPosition = transform.position + new Vector3(0f, 0.273f, 0f) + turret.right * 0.99f; //REMOVE ME WHEN MODEL GETS FIXED
            Quaternion intialRotation = turret.rotation * Quaternion.Euler(0, 90, 0); //REMOVE ME WHEN MODEL GETS FIXED
            //UNCOMMENT ME WHEN MODEL GETS FIXED
            //Vector3 intialPosition = transform.position + new Vector3(0f, 0.273f, 0f) + turret.right * 0.99f;
            //Quaternion intialRotation = turret.rotation * Quaternion.Euler(0, 90, 0);
            Instantiate(prefabEnemyBullet, intialPosition, intialRotation, enemyBulletContainer);
            cooldownTimeStamp = Time.time + cooldownTime;
        }
    }
}
