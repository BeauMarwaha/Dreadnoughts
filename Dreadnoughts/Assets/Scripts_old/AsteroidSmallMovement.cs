using UnityEngine;

/// <summary>
/// Conner Catanese
/// Sets starting rotation and velocity (on top of SimpleMovement)
/// </summary>
public class AsteroidSmallMovement : SimpleMovement
{
    // Defines
    public float angleRange = 15f;
    public float speedMin = 0.1f;
    public float speedMax = 0.2f;

    /// <summary>
    /// Start()
    /// Used for initializtion
    /// </summary>
    internal new void Start()
    {
        base.Start();

        // Calculate random rotation from heading
        Quaternion spread = Quaternion.Euler(0, 0, Random.Range(-angleRange, angleRange));

        // Set velocity
        velocity = spread * transform.up.normalized * Random.Range(speedMin, speedMax);

        // Set rotation
        transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)));
    }
}