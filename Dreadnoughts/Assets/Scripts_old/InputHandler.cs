using UnityEngine;

/// <summary>
/// Conner Catanese
/// Handle keyboard
/// </summary>
public class InputHandler : MonoBehaviour
{
    // Input defines
    public KeyCode shipForward = KeyCode.UpArrow;
    public KeyCode shipBackward = KeyCode.DownArrow;
    public KeyCode shipLeft = KeyCode.LeftArrow;
    public KeyCode shipRight = KeyCode.RightArrow;
    public KeyCode shipShoot = KeyCode.Space;
    public KeyCode gameStart = KeyCode.Return;

    // Tie-ins
    public GameObject ship;

    // Fields
    private bool lockdown = false;
    private ShipMovement shipMovement;
    private ShipShooting shipShooting;
    private ShipInfo shipInfo;
    private GUIHandler guiHandler;
    private AsteroidSpawner asteroidSpawner;

    public bool Lockdown
    {
        set
        {
            lockdown = value;
        }
    }

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    void Start()
    {
        shipMovement = ship.GetComponent<ShipMovement>();
        shipShooting = ship.GetComponent<ShipShooting>();
        shipInfo = ship.GetComponent<ShipInfo>();
        guiHandler = GetComponent<GUIHandler>();
        asteroidSpawner = GetComponent<AsteroidSpawner>();
    }

    /// <summary>
    /// Update()
    /// Called once per frame
    /// </summary>
    void Update()
    {
        if (!lockdown)
        {
            // Ship movement
            shipMovement.InputForward = Input.GetKey(shipForward);
            shipMovement.InputBackward = Input.GetKey(shipBackward);
            shipMovement.InputLeft = Input.GetKey(shipLeft);
            shipMovement.InputRight = Input.GetKey(shipRight);

            // Shooting
            shipShooting.InputShoot = Input.GetKeyDown(shipShoot);

            // Game start
            if (Input.GetKeyDown(gameStart))
            {
                shipInfo.OnCollision();
                guiHandler.Stage = 1;
                asteroidSpawner.InputStart = true;
            }
        }
        else
        {
            shipMovement.InputForward = false;
            shipMovement.InputBackward = false;
            shipMovement.InputLeft = false;
            shipMovement.InputRight = false;
            shipShooting.InputShoot = false;
        }
    }
}