using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Beau Marwaha
/// Handles the game win condition.
/// </summary>
public class WinHandler : MonoBehaviour {

    public GameObject winScreen;

	// Update is called once per frame
	void Update () {
        // Retrieve all child transforms
        Transform[] children = GetComponentsInChildren<Transform>();

        // If there are no remaining child transforms all enemies have been destroyed and the game is over
        if(children.Length == 1)
        {
            // SHow the win screen
            winScreen.SetActive(true);
        }
	}
}
