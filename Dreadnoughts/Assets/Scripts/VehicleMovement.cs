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
    private Vector3 vehiclePos;
    private Vector3 velocity;
    private Vector3 direction;
    private Vector3 turretDirection;
    private Vector3 acceleration;

    private Transform turretTransform;

    public float angleOfRotation;
    public float turretAngle;
    public float maxSpeed;
    public float accelRate;

    // Use this for initialization
    void Start()
    {
        //set initial values
        ResetPosition();
        maxSpeed = 2.5f;
        turretTransform = transform.GetChild(1);
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
        //if the user presses the I key accelerate the vehicle
        if (Input.GetKey(KeyCode.I))
        {
            accelRate = 5f;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            //if the user presses the K key decelerate the vehicle
            accelRate = -5f;
        }
        else
        { 
            //if the user does not press either key stop acceleration and decelerate the vehicle back to a standstill
            //stop acceleration
            accelRate = 0;

            //slow down the vehicle
            velocity = Vector3.ClampMagnitude(velocity, velocity.magnitude * .8f);

            //bring the car to a standstill after reaching a very small current speed
            if (velocity.magnitude <= .000001)
            {
                velocity = Vector3.zero;
            }
        }

        //accelRate * direction = accel vector
        acceleration = accelRate * direction.normalized * Time.deltaTime;
        //add accel to vel
        velocity += acceleration;
        //limit vel
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        //add velocity to position
        vehiclePos += velocity * Time.deltaTime;
    }

    /// <summary>
    /// Rotate this instance based on the direction its facing
    /// </summary>
    void Rotate()
    {
        //if J key is pressed rotate to the left 2 deg
        if (Input.GetKey(KeyCode.J))
        {
            direction = Quaternion.Euler(0, -2, 0) * direction;
            turretDirection = Quaternion.Euler(0, -2, 0) * turretDirection;
            angleOfRotation -= 2f;
            turretAngle -= 2f;
        }

        //if L key is pressed rotate to the right 2 deg
        if (Input.GetKey(KeyCode.L))
        {
            direction = Quaternion.Euler(0, 2, 0) * direction;
            turretDirection = Quaternion.Euler(0, 2, 0) * turretDirection;
            angleOfRotation += 2f;
            turretAngle += 2f;
        }
    }

    /// <summary>
    /// Rotate this instance based on the direction its facing
    /// </summary>
    void RotateTurret()
    {
        //if A key is pressed rotate to the left 1 deg
        if (Input.GetKey(KeyCode.A))
        {
            turretDirection = Quaternion.Euler(0, -1, 0) * turretDirection;
            turretAngle -= 1f;
        }

        //if D key is pressed rotate to the right 1 deg
        if (Input.GetKey(KeyCode.D))
        {
            turretDirection = Quaternion.Euler(0, 1, 0) * turretDirection;
            turretAngle += 1f;
        }
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
        return vehiclePos;
    }

    /// <summary>
    /// Resets the position of the vehicle.
    /// </summary>
    public void ResetPosition()
    {
        vehiclePos = new Vector3(0, 0.16f, 0); // Custom start position
        velocity = Vector3.zero;
        direction = Vector3.forward;
        turretDirection = Vector3.forward;
        angleOfRotation = 0;
        accelRate = 0;
    }

    /// <summary>
    /// Sets the transform rotation and position of the vehicle
    /// </summary>
    void SetTransform()
    {
        //"Draw" the vehicle at its calculated position 
        transform.position = vehiclePos;

        //rotate the vehicle to its calculated rotation
        transform.rotation = Quaternion.Euler(0, angleOfRotation, 0);
        turretTransform.rotation = Quaternion.Euler(0, turretAngle, 0);
    }
}
