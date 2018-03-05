using UnityEngine;

/// <summary>
/// Conner Catanese
/// Handles score and lives
/// </summary>
public class PlayerData : MonoBehaviour
{
    // Defines
    public int numLives = 3;
    public int pointValue = 20;

    // Fields
    private int score;
    private int lives;

    // Properties
    public int Score
    {
        get
        {
            return score;
        }
    }
    public int Lives
    {
        get
        {
            return lives;
        }
    }

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    void Start()
    {
        score = 0;
        lives = numLives;
    }

    /// <summary>
    /// AddScore()
    /// When player shoots an asteroid
    /// </summary>
    public void AddScore()
    {
        score += pointValue;
    }

    /// <summary>
    /// LoseLife()
    /// When player takes a hit
    /// </summary>
    public void LoseLife()
    {
        lives -= 1;
    }
}