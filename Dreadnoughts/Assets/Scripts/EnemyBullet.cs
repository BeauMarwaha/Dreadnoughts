using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private Vector3 nVector;
    private float bulletSpeed = 5.0f;
    private int bulletDamage = 10; // 10 health per hit

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
        Destroy(this.gameObject, 5);
    }

    void OnCollisionEnter(Collision col)
    {
        // On collision damage the player and destroy the bullet
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(bulletDamage);
            //col.gameObject.health -= 5; // Reduce the player health here
        }
    }
}
