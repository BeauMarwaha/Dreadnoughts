using UnityEngine;

/// <summary>
/// Conner Catanese
/// Controls ship movement and drifting
/// </summary>
public class ShipMovement : MonoBehaviour
{
    // Linear transform fields
    private Vector3 linearPosition;
    private Vector3 linearVelocity = new Vector3();
    private Vector3 linearAcceleration = new Vector3();
    // Angular transform fields
    private Quaternion angularPosition;
    private float angularVelocity = 0f;
    private float angularAcceleration = 0f;

    // Linear defines
    public Vector3 startPosition = new Vector3(0, 0, 0);
    public float forwardPower = 0.015f;
    public float reversePower = -0.01f;
    public float maxSpeed = 1f;
    public float linearDecay = -0.02f;
    // Angular defines
    public float rotationPower = 0.24f;
    public float maxRotation = 5f;
    public float angularDecay = -0.03f;

    // Screen edge defines
    public float xMin = -38.5f;
    public float yMin = -21.5f;
    public float xMax = 38.5f;
    public float yMax = 21.5f;

    // Screen size fields
    private Vector3 xDiff;
    private Vector3 yDiff;

    // Movement input defines
    private bool inputForward = false;
    private bool inputBackward = false;
    private bool inputLeft = false;
    private bool inputRight = false;

    // Properties
    public bool InputForward
    {
        set
        {
            inputForward = value;
        }
    }
    public bool InputBackward
    {
        set
        {
            inputBackward = value;
        }
    }
    public bool InputLeft
    {
        set
        {
            inputLeft = value;
        }
    }
    public bool InputRight
    {
        set
        {
            inputRight = value;
        }
    }

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    void Start()
    {
        // Record the ship's position and rotation
        linearPosition = transform.position;
        angularPosition = transform.rotation;

        // Record screen size
        xDiff = Vector3.right * (xMax - xMin);
        yDiff = Vector3.up * (yMax - yMin);
    }

    /// <summary>
    /// Update()
    /// Called once per frame
    /// </summary>
    void Update()
    {
        // Get accelerations
        linearAcceleration = GetLinearAcceleration();
        angularAcceleration = GetAngularAcceleration();

        // Calculate velocities and clamp maximums
        linearVelocity = Vector3.ClampMagnitude(linearVelocity + linearAcceleration, maxSpeed);
        angularVelocity = Mathf.Max(-maxRotation, Mathf.Min(maxRotation, angularVelocity + angularAcceleration));

        // Calculate positions
        linearPosition += linearVelocity;
        angularPosition *= Quaternion.Euler(Vector3.forward * angularVelocity);

        // Set transform
        transform.position = linearPosition;
        transform.rotation = angularPosition;

        // Wrap position in screen
        WrapPosition();
    }

    /// <summary>
    /// WrapPosition()
    /// Keeps ship inside screen bounds
    /// </summary>
    private void WrapPosition()
    {
        // Wrap on X
        if (transform.position.x < xMin)
            linearPosition += xDiff;
        else if (transform.position.x > xMax)
            linearPosition -= xDiff;

        // Wrap on Y
        if (transform.position.y < yMin)
            linearPosition += yDiff;
        else if (transform.position.y > yMax)
            linearPosition -= yDiff;
    }

    /// <summary>
    /// GetAngularAcceleration()
    /// Handles keypresses to determine angular acceleration for the current frame
    /// </summary>
    /// <returns>float of current angular acceleration</returns>
    private float GetAngularAcceleration()
    {
        float angAccel = 0f;

        // Keyboard controls for direction
        if (inputLeft)
            angAccel += rotationPower;
        if (inputRight)
            angAccel -= rotationPower;

        // Decay
        angAccel += angularVelocity * angularDecay;

        return angAccel;
    }

    /// <summary>
    /// GetLinearAcceleration()
    /// Handles keypresses to determine linear acceleration for the current frame
    /// </summary>
    /// <returns>Vector3 of current linear acceleration</returns>
    private Vector3 GetLinearAcceleration()
    {
        Vector3 linAccel = transform.up;

        // Keyboard controls for direction
        if (inputForward)
        {
            if (inputBackward)
                linAccel *= 0;
            else
                linAccel *= forwardPower;
        }
        else if (inputBackward)
            linAccel *= reversePower;
        else
            linAccel *= 0;

        // Decay
        linAccel += linearVelocity * linearDecay;

        return linAccel;
    }

    /// <summary>
    /// ResetPosition()
    /// Reset ship after collision
    /// </summary>
    public void ResetPosition()
    {
        linearPosition = startPosition;
        angularPosition = Quaternion.identity;

        linearVelocity = Vector3.zero;
        angularVelocity = 0f;
    }
}