using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame_BTN : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("Main");
    }
}
