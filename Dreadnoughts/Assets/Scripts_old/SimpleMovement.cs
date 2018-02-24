using UnityEngine;

/// <summary>
/// Conner Catanese
/// Basic movement for non-ship entities
/// </summary>
public class SimpleMovement : MonoBehaviour
{
    // Defines
    public float despawnDistance = 100f;

    // Fields
    internal Vector3 velocity;
    internal Vector3 startPosition;

    /// <summary>
    /// Start()
    /// Used for initializtion
    /// </summary>
    internal void Start()
    {
        // Grab start position
        startPosition = transform.position;
    }

    /// <summary>
    /// Update()
    /// Called once per frame
    /// </summary>
    internal void Update()
    {
        transform.position += velocity;
        // Destroy after the asteroid has traveled far enough
        if (CheckDespawn())
            Destroy(gameObject);
    }

    /// <summary>
    /// Checks for when to despawn object
    /// </summary>
    /// <returns>if condition is met</returns>
    internal bool CheckDespawn()
    {
        return Vector3.Distance(transform.position, startPosition) > despawnDistance;
    }
}