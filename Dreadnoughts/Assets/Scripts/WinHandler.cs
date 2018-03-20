using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: Beau Marwaha
/// Handles the game win condition.
/// </summary>
public class WinHandler : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        // Retrieve all child transforms
        Transform[] children = GetComponentsInChildren<Transform>();

        // If there are no remaining child transforms all enemies have been destroyed and the game is over
        if(children.Length == 1)
        {
            // Show the win screen
            SceneManager.LoadScene("Win");
        }
	}
}
