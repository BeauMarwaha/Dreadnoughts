using UnityEngine;

/// <summary>
/// Conner Catanese
/// Bullet-specific information
/// </summary>
public class BulletInfo : ObjectInfo
{
    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    private new void Start()
    {
        base.Start();
        radius = 0.7f;
    }

    /// <summary>
    /// OnCollision()
    /// Object-specific on-collision action
    /// </summary>
    public override void OnCollision()
    {
        // Add score
        // Destroy bullet
        Destroy(gameObject);
    }
}