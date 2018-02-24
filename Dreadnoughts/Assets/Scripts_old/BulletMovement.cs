using UnityEngine;

/// <summary>
/// Conner Catanese
/// Sets starting rotation and velocity (on top of SimpleMovement)
/// </summary>
public class BulletMovement : SimpleMovement
{
    // Bullet defines
    public float speed = 0.8f;

    // Screen edge defines
    public float xMin = -38.5f;
    public float yMin = -21.5f;
    public float xMax = 38.5f;
    public float yMax = 21.5f;

    // Fields
    internal Transform shooterTransform;

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    internal new void Start()
    {
        // Set velocity using ship direction
        shooterTransform = GameObject.Find("Ship").transform;
        velocity = shooterTransform.up.normalized * speed;

        // Put bullet under ship
        transform.position += Vector3.forward;
    }

    /// <summary>
    /// CheckDespawn()
    /// Checks against screen bounds for despawning
    /// </summary>
    /// <returns>if condition is met</returns>
    internal new bool CheckDespawn()
    {
        return transform.position.x < xMin || transform.position.x > xMax || transform.position.y < yMin || transform.position.y > yMax;
    }
}