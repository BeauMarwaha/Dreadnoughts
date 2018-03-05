/// <summary>
/// Conner Catanese
/// Small-Asteroid-specific information
/// </summary>
public class AsteroidSmallInfo : ObjectInfo
{
    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    private new void Start()
    {
        base.Start();
        radius = 1.5f;
    }

    /// <summary>
    /// OnCollision()
    /// Object-specific on-collision action
    /// </summary>
    public override void OnCollision()
    {
        // Destroy asteroid
        Destroy(gameObject);
    }
}