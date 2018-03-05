using UnityEngine;

/// <summary>
/// Conner Catanese
/// Large-Asteroid-specific information
/// </summary>
public class AsteroidLargeInfo : ObjectInfo
{
    //// Defines
    //public GameObject smallAsteroidPrefab;

    // Fields
    private Transform asteroidContainerTransform;

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    private new void Start()
    {
        base.Start();
        asteroidContainerTransform = GameObject.Find("AsteroidContainer").transform;
        radius = 3f;
    }

    /// <summary>
    /// OnCollision()
    /// Object-specific on-collision action
    /// </summary>
    public override void OnCollision()
    {
        //// Spawn small asteroids
        //Instantiate(smallAsteroidPrefab, transform.position, transform.rotation * Quaternion.Euler(Vector3.forward * 20f), asteroidContainerTransform);
        //Instantiate(smallAsteroidPrefab, transform.position, transform.rotation * Quaternion.Euler(Vector3.forward * -20f), asteroidContainerTransform);

        // Destroy this asteroid
        Destroy(gameObject);
    }
}