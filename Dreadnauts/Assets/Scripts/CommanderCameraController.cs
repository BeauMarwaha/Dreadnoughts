using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Beau Marwaha
/// Camera Controller for the commander's camera.
/// </summary>
public class CommanderCameraController : MonoBehaviour {

    // attributes
    public float speed = 5.0f;
    public Transform parentTransform;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Have the camera follow the mouse x axis
        transform.RotateAround(parentTransform.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
    }
}
