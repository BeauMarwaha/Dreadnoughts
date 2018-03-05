/// <summary>
/// Conner Catanese
/// Ship-specific information
/// </summary>
public class ShipInfo : ObjectInfo
{
    // Fields
    private ShipInvincibility shipInvincibility;

    // Public info
    public bool isInvincible;

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    private new void Start()
    {
        base.Start();
        radius = 0.3f;
        shipInvincibility = GetComponent<ShipInvincibility>();
        isInvincible = true;
    }

    /// <summary>
    /// OnCollision()
    /// Object-specific on-collision action
    /// </summary>
    public override void OnCollision()
    {
        shipInvincibility.TakeHit();
    }
}