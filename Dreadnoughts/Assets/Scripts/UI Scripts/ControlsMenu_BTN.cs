using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu_BTN : MonoBehaviour {
    public void LoadGame()
    {
        SceneManager.LoadScene("ControlsMenu");
    }
}
