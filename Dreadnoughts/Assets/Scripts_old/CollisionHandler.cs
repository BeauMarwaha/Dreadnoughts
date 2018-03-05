using System;
using UnityEngine;

/// <summary>
/// Conner Catanese
/// Determine collisions between objects
/// </summary>
public class CollisionHandler : MonoBehaviour
{
    // Defines
    public GameObject ship;
    public Transform asteroidContainer;
    public Transform bulletContainer;

    // Fields
    private PlayerData playerData;
    private ShipInfo shipInfo;
    private AsteroidSpawner spawner;
    private GUIHandler guiHandler;
    private InputHandler inputHandler;

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        shipInfo = ship.GetComponent<ShipInfo>();
        spawner = GetComponent<AsteroidSpawner>();
        guiHandler = GetComponent<GUIHandler>();
        inputHandler = GetComponent<InputHandler>();
    }

    /// <summary>
    /// Update()
    /// Called once per frame
    /// </summary>
    void Update()
    {
        // Asteroid/Bullet collisions
        foreach (Transform asteroid in asteroidContainer)
        {
            foreach (Transform bullet in bulletContainer)
            {
                if (Collision(asteroid,bullet))
                {
                    asteroid.GetComponent<ObjectInfo>().OnCollision();
                    bullet.GetComponent<BulletInfo>().OnCollision();
                    playerData.AddScore();
                }
            }
        }

        // Asteroid/Ship collisions
        if (!shipInfo.isInvincible)
        {
            foreach (Transform asteroid in asteroidContainer)
            {
                if (Collision(asteroid, ship.transform))
                {
                    asteroid.GetComponent<ObjectInfo>().OnCollision();
                    shipInfo.OnCollision();

                    playerData.LoseLife();

                    if (playerData.Lives == 0)
                        EndGame();

                    break;
                }
            }
        }
    }

    /// <summary>
    /// EndGame()
    /// We're done here
    /// </summary>
    private void EndGame()
    {
        // Stop asteroid spawning
        spawner.enabled = false;
        StopAllCoroutines();
        Destroy(GameObject.Find("AsteroidContainer"));
        Destroy(GameObject.Find("BulletContainer"));
        // Clear asteroids and bullets
        foreach (Transform asteroid in asteroidContainer)
            Destroy(asteroid.gameObject);
        foreach (Transform bullet in bulletContainer)
            Destroy(bullet.gameObject);
        // Reset ship position
        shipInfo.OnCollision();
        // Change GUI to last iteration
        guiHandler.Stage = 2;
        // Stop movement
        inputHandler.Lockdown = true;
        // Stop everything
        enabled = false;
    }

    /// <summary>
    /// Collision(Transform, Transform)
    /// Tests whether gameObjects are colliding using Bounding Circles
    /// </summary>
    /// <param name="obj1">First object transform</param>
    /// <param name="obj2">Second object transform</param>
    /// <returns>Whether first and second objects are colliding with eachother</returns>
    public static bool Collision(Transform obj1, Transform obj2)
    {
        ObjectInfo sprite1 = obj1.GetComponent<ObjectInfo>();
        ObjectInfo sprite2 = obj2.GetComponent<ObjectInfo>();

        float distance = (sprite2.center - sprite1.center).magnitude; // distance from the center of one object to the other
        float totalSize = sprite1.radius + sprite2.radius; // combined radii of objects

        bool collision = totalSize > distance; // collision if combined radii is greater than distance from center to center

        return collision;
    }
}