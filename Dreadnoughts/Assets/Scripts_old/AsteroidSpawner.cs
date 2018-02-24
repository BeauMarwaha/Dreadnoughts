using System.Collections;
using UnityEngine;

/// <summary>
/// Conner Catanese
/// Handles spawning of asteroids
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    // Asteroid defines
    public GameObject asteroidPrefab;
    public Transform asteroidContainer;

    // Spawn rate defines
    public float initialSpawnDelaySeconds = 2.0f;
    public float spawnDelayIncrementFactor = 0.9f;
    public float minSpawnTimer = 0.05f;
    public int spawnRateIncrementFrequency = 10;

    // Screen edge defines
    public float xMin = -38.5f;
    public float yMin = -21.5f;
    public float xMax = 38.5f;
    public float yMax = 21.5f;
    public float spawnRadiusFactor = 1.1f;

    // Fields
    private bool imReady = true;
    private bool inputStart = false;
    private float spawnDelaySeconds;
    private int spawnIncrementCounter = 0;

    // Properties
    public bool InputStart
    {
        set
        {
            inputStart = value;
        }
    }

    // Screen fields
    private Vector3 center;
    private float radius;

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    void Start()
    {
        spawnDelaySeconds = initialSpawnDelaySeconds;

        // Do coordinate math
        center = new Vector3((xMax + xMin) / 2.0f, (yMax + yMin) / 2.0f, 0f);
        radius = Mathf.Sqrt(Mathf.Pow((xMax - xMin), 2) + Mathf.Pow((yMax - yMin), 2)) / 2;
    }

    /// <summary>
    /// Update()
    /// Called once per frame
    /// </summary>
    void Update()
    {
        if (inputStart && imReady)
        {
            StartCoroutine("Spawn");
            imReady = false;
        }
    }

    /// <summary>
    /// Spawn()
    /// Spawns asteroids, gradually increasing in frequency over time
    /// </summary>
    /// <returns>IEnumerator handle to allow waiting without hanging entire game</returns>
    IEnumerator Spawn()
    {
        while (true)
        {
            // Spawns the asteroid
            SpawnAsteroid();
            // Counts up towards speedup of spawn rate
            spawnIncrementCounter++;
            if (spawnIncrementCounter == spawnRateIncrementFrequency)
            {
                // Reduces spawn delay
                spawnDelaySeconds *= spawnDelayIncrementFactor;
                if (spawnDelaySeconds < minSpawnTimer)
                    break;
                spawnIncrementCounter = 0;
            }
            // Wait before spawning
            yield return new WaitForSeconds(spawnDelaySeconds);
        }

        // Switch to optimized function
        StartCoroutine("MaxDifficulty");
        yield return null;
    }

    /// <summary>
    /// MaxDifficulty()
    /// Optimized version of Spawn() to allow for more suffering with maximum FPS
    /// </summary>
    /// <returns>IEnumerator handle to allow waiting without hanging entire game</returns>
    IEnumerator MaxDifficulty()
    {
        while (true)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(minSpawnTimer);
        }
    }

    /// <summary>
    /// SpawnAsteroid()
    /// Instantiates a single asteroid
    /// </summary>
    void SpawnAsteroid()
    {
        // Position = (Screen Center) + (Vector in a random direction, with a length that puts it just a bit out of the screen)
        Vector3 spawnPosition = center + RandomZRotation() * Vector3.up * radius * spawnRadiusFactor;
        // Instantiate
        Instantiate(asteroidPrefab, spawnPosition, RandomZRotation(), asteroidContainer.transform);
    }

    /// <summary>
    /// RandomAngle()
    /// Generates a Quaternion corresponding to a random rotation around the z axis
    /// </summary>
    /// <returns>The generated Quaternion</returns>
    Quaternion RandomZRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0f, 360f));
    }
}