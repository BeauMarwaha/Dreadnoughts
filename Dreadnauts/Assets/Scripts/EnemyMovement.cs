using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Vector3 vehiclePosition;
    public Vector3 velocity;
    public Vector3 direction;

    // necessary for accelration / "speeding up"
    public Vector3 acceleration;
    public float accelRate;             // constant rate of acceleration, 0.001f
    public float maxSpeed;              // 0.05f

    // Fields for movement
    public float anglePerFrame;         // 1f
    public float totalRotation;         // 0f

    // Behavior variables
    public int DecisionTimer; // How long until a new decision must be made
    public float Decision; // holds randomly generated numbers for decision-making || 1-5 forward > 6-7 left > 8-9 right > 10 stop
    public bool DecisionMade; // has a decision been made yet? Is it time for a new one?
    public bool goingLeft; // Is the tank going left?
    public bool goingRight; // Is the tank going right?
    public bool goingForward; // Is the tank going forward?
    public bool Waiting; // Is the tank waiting?

    public int Health; // The health value of the tank --> For KV2, health should be at least 3
    public Vector3 minBound;
    public Vector3 maxBound;

    // Use this for initialization
    void Start()
    {
        // Set behavior variable values
        Health = 3;
        DecisionTimer = 240; // Recommended: 240 for 4 seconds
        DecisionMade = false;
        goingLeft = false;
        goingRight = false;
        goingForward = false;
        Waiting = false;
        accelRate = 0.01f;
        maxSpeed = 0.10f;
        anglePerFrame = 1.0f;
        minBound = new Vector3(-42.0f, 0.0f, -42.0f);
        maxBound = new Vector3(42.0f, 0.0f, 42.0f);

        // Grab the position from the transform component
        vehiclePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (DecisionTimer <= 0)
        {
            DecisionMade = false;
            DecisionTimer = 240;
        }
        // generate a random number for decision-making if a decision hasn't been made yet
        if (DecisionMade == false && DecisionTimer > 0)
        {
            Decision = Random.Range(1f, 10f);
            DecisionMade = true;
        }

        // make a decision if one hasn't been made yet
        if (DecisionMade == true && DecisionTimer > 0)
        {
            if (this.transform.position.x > maxBound.x || this.transform.position.z > maxBound.z || this.transform.position.x < minBound.x || this.transform.position.z < minBound.z)
            {
                this.transform.Rotate(20.0f * this.transform.up * Time.deltaTime);
                Vector3 centerToObj = new Vector3(0.1f - this.transform.position.x, 0.0f, 0.1f - this.transform.position.z);
                this.transform.position += centerToObj.normalized * 0.05f;
            }
            else
            {

                DecisionTimer--;
                // turn left (6-7)
                if (Decision > 5f && Decision <= 7f)
                {
                    goingLeft = true;
                    goingRight = false;
                    goingForward = false;
                    Waiting = false;
                    // rotate left, positive rotation
                    this.transform.Rotate(-10.0f * this.transform.up * Time.deltaTime);
                }

                // turn right (8-9)
                if (Decision > 7f && Decision <= 9f)
                {
                    goingRight = true;
                    goingLeft = false;
                    goingForward = false;
                    Waiting = false;
                    // rotate right, negative rotation
                    this.transform.Rotate(10.0f * this.transform.up * Time.deltaTime);
                }

                // go forward (1-5)
                // Step 4: CALCULATE ACCELERATION
                // Step 4B: CALCULATE ACCELERATION WHILE "I" KEY IS HELD, AND...
                if (Decision <= 5f)
                {
                    goingForward = true;
                    Waiting = false;
                    goingRight = false;
                    goingLeft = false;
                    acceleration = accelRate * this.transform.forward;

                    velocity += acceleration;
                    //velocity = velocity.magnitude * direction;
                    this.transform.position += velocity;

                }
            }
        }
        else
        {
            // If no decision, maybe decelerate
            Waiting = true;
            goingLeft = false;
            goingRight = false;
            goingForward = false;
        }

        // DECELERATE
        if (velocity.magnitude > 0)
        {
            velocity = velocity * 0.8f;
        }
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);


    }

}