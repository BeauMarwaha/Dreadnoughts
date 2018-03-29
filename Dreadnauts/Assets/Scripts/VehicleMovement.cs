using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Beau Marwaha
/// Vehicle movement.
/// </summary>
public class VehicleMovement : MonoBehaviour
{

    //attributes
    private Vector3 vehiclePosition;
    private float vehicleLinearSpeed;
    private Vector3 vehicleLinearAcceleration;

    private Vector3 vehicleDirection;
    private float vehicleAngularAcceleration;
    private float vehicleAngularVelocity;

    private Vector3 turretDirection;
    private float turretAngularAcceleration;
    private float turretAngularVelocity;

    public Transform turretTransform;

    public float angleOfRotation;
    public float turretAngle;
    public float maxVehicleLinearSpeed;
    public float maxVehicleAngularSpeed;
    public float maxTurretAngularSpeed;

    // Use this for initialization
    void Start()
    {
        //set initial values
        ResetPosition();
        maxVehicleLinearSpeed = 2.5f;
        maxVehicleAngularSpeed = 2.5f;
        maxTurretAngularSpeed = 2.5f;
        turretTransform = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //move the vehicle around the screen
        Rotate();
        RotateTurret();
        Drive();
        SetTransform();
    }

    /// <summary>
    /// Drive this instance.
    /// Calculate the velocity and the resulting position of the vehicle
    /// </summary>
    void Drive()
    {
        float tempAccelRate = 0;

        //if the user presses the I key accelerate the vehicle
        if (Input.GetKey(KeyCode.I))
        {
            tempAccelRate += 5f;
        }

        //if the user presses the K key decelerate the vehicle
        if (Input.GetKey(KeyCode.K))
        {
            tempAccelRate -= 5f;
        }

        //decelerate the vehicle, providing natural soft-cap on speed
        tempAccelRate += vehicleLinearSpeed * -1.5f;

        //add accel to vel
        vehicleLinearSpeed += tempAccelRate * Time.deltaTime;
        
        //limit vel
        vehicleLinearSpeed = Mathf.Max(Mathf.Min(vehicleLinearSpeed, maxVehicleLinearSpeed), -maxVehicleLinearSpeed);
        
        //bring the car to a standstill after reaching a very small current speed
        if (vehicleLinearSpeed <= 0.01f && vehicleLinearSpeed >= -0.01f)
        {
            vehicleLinearSpeed = 0f;
        }

        //add velocity to position
        vehiclePosition += vehicleLinearSpeed * vehicleDirection.normalized * Time.deltaTime;
    }

    /// <summary>
    /// Rotate this instance based on the direction its facing
    /// </summary>
    void Rotate()
    {
        float tempRotAccelRate = 0;

        //if J key is pressed rotate to the left
        if (Input.GetKey(KeyCode.J))
        {
            tempRotAccelRate -= 2.5f;
        }

        //if L key is pressed rotate to the right
        if (Input.GetKey(KeyCode.L))
        {
            tempRotAccelRate += 2.5f;
        }

        //provide natural friction and soft-cap on rotational velocity
        tempRotAccelRate += vehicleAngularVelocity * -5f;

        //accelRate * time = accel scalar
        vehicleAngularAcceleration = tempRotAccelRate * Time.deltaTime;

        //add accel to vel
        vehicleAngularVelocity += vehicleAngularAcceleration;

        //limit angular vel
        vehicleAngularVelocity = Mathf.Min(Mathf.Max(vehicleAngularVelocity, -maxVehicleAngularSpeed), maxVehicleAngularSpeed);

        //bring the car to a rotational standstill after reaching a very small current speed
        if (Mathf.Abs(vehicleAngularVelocity) <= 0.01f)
        {
            vehicleAngularVelocity = 0f;
        }

        //add velocity to position
        Quaternion rotationStrength = Quaternion.Euler(0, vehicleAngularVelocity, 0);
        vehicleDirection = rotationStrength * vehicleDirection;
        turretDirection = rotationStrength * turretDirection;
        angleOfRotation += vehicleAngularVelocity;
        turretAngle += vehicleAngularVelocity;
    }

    /// <summary>
    /// Rotate this instance based on the direction its facing
    /// </summary>
    void RotateTurret()
    {
        float tempRotAccelRate = 0;
        float rotRate = 2f;

        //if Shift key is pressed rotate faster
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rotRate = 5f;
        }

        //if A key is pressed rotate to the left
        if (Input.GetKey(KeyCode.A))
        {
            tempRotAccelRate -= rotRate;
        }

        //if D key is pressed rotate to the right
        if (Input.GetKey(KeyCode.D))
        {
            tempRotAccelRate += rotRate;
        }

        //provide natural friction and soft-cap on rotational velocity
        tempRotAccelRate += turretAngularVelocity * -8f;

        //accelRate * time = accel scalar
        turretAngularAcceleration = tempRotAccelRate * Time.deltaTime;

        //add accel to vel
        turretAngularVelocity += turretAngularAcceleration;

        //limit angular vel
        turretAngularVelocity = Mathf.Min(Mathf.Max(turretAngularVelocity, -maxTurretAngularSpeed), maxTurretAngularSpeed);

        //bring the car to a rotational standstill after reaching a very small current speed
        if (Mathf.Abs(turretAngularVelocity) <= 0.03f)
        {
            turretAngularVelocity = 0f;
        }

        //add velocity to position
        Quaternion rotationStrength = Quaternion.Euler(0, turretAngularVelocity, 0);
        turretDirection = rotationStrength * turretDirection;
        turretAngle += turretAngularVelocity;
    }

    /// <summary>
    /// Gets the current rotation of the vehicle.
    /// </summary>
    /// <returns>The rotation.</returns>
    public float GetRotation()
    {
        return angleOfRotation;
    }

    /// <summary>
    /// Gets the current vehicle position.
    /// </summary>
    /// <returns>The position.</returns>
    public Vector3 GetPosition()
    {
        return vehiclePosition;
    }

    /// <summary>
    /// Resets the position of the vehicle.
    /// </summary>
    public void ResetPosition()
    {
        vehiclePosition = new Vector3(0, 0.05f, 0); // Custom start position -- MODIFIED
        vehicleLinearSpeed = 0f;
        vehicleDirection = Vector3.forward;
        turretDirection = Vector3.forward;
        angleOfRotation = -3.197f;
    }

    /// <summary>
    /// Sets the transform rotation and position of the vehicle
    /// </summary>
    void SetTransform()
    {
        //"Draw" the vehicle at its calculated position 
        transform.position = vehiclePosition;

        //rotate the vehicle to its calculated rotation
        transform.rotation = Quaternion.Euler(0, angleOfRotation, 0);
        turretTransform.rotation = Quaternion.Euler(0, turretAngle, 0);
    }
}
