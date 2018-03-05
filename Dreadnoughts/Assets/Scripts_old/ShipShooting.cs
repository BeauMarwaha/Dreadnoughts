using UnityEngine;

/// <summary>
/// Conner Catanese
/// Handles firing of projectiles from the ship
/// </summary>
public class ShipShooting : MonoBehaviour
{
    // Defines
    public GameObject bulletPrefab;
    public Transform bulletContainer;
    public int maxShotsOnScreen = 5;

    // Fields
    private bool inputShoot = false;

    // Properties
    public bool InputShoot
    {
        set
        {
            inputShoot = value;
        }
    }

    /// <summary>
    /// Update()
    /// Called once per frame
    /// </summary>
    void Update()
    {
        Shoot();
    }

    /// <summary>
    /// Shoot()
    /// Handle ship shooting
    /// </summary>
    void Shoot()
    {
        //if (inputShoot && GameObject.FindGameObjectsWithTag("bullet").Length < maxShotsOnScreen)
        if (inputShoot)
        {
            // Shoot
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation, bulletContainer);
            bullet.tag = "bullet";
        }
    }
}