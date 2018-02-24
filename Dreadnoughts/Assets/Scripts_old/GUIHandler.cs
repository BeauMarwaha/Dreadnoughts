using UnityEngine;

/// <summary>
/// Conner Catanese
/// Draw GUI
/// </summary>
public class GUIHandler : MonoBehaviour
{
    // Fields
    private int stage = 0;
    private PlayerData playerData;

    // Properties
    public int Stage
    {
        set
        {
            stage = value;
        }
    }

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    private void Start()
    {
        playerData = GetComponent<PlayerData>();
    }

    /// <summary>
    /// OnGUI()
    /// Draw information to screen
    /// </summary>
    private void OnGUI()
    {
        // Display instructions to the user
        if (stage == 0)
            GUI.Box(new Rect(20, 20, 260, 60), "Use arrow keys for movement\nand space to shoot.\nPress return to begin!");
        else if (stage == 1)
            GUI.Box(new Rect(20, 20, 160, 40), "Score: " + playerData.Score + "\nLives: " + playerData.Lives);
        else
            GUI.Box(new Rect(20, 20, 160, 40), "Game Over\nFinal Score: " + playerData.Score);
    }
}