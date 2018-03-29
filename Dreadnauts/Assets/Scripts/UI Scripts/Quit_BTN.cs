using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Quit_BTN : MonoBehaviour {

    public void QuittheGame()
    {
        Application.Quit();
        Debug.Log("You have clicked the button!");
    }
	
}
