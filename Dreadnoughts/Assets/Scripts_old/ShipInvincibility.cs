using System.Collections;
using UnityEngine;

/// <summary>
/// Conner Catanese
/// Gives the player a breather when they die
/// </summary>
public class ShipInvincibility : MonoBehaviour
{
    // Defines
    public float invincibilitySeconds = 5.0f;
    public bool resetPositionOnHit = true;

    // Fields
    private ShipMovement movement;
    //private SpriteRenderer sprite;
    private MeshRenderer mesh;
    private ShipInfo info;

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    void Start()
    {
        movement = GetComponent<ShipMovement>();
        //sprite = GetComponent<SpriteRenderer>();
        mesh = GetComponent<MeshRenderer>();
        info = GetComponent<ShipInfo>();
    }

    /// <summary>
    /// TakeHit()
    /// When the ship hits an asteroid
    /// </summary>
    public void TakeHit()
    {
        if (resetPositionOnHit)
            movement.ResetPosition();
        StartCoroutine("BeInvincible");
    }

    /// <summary>
    /// BeInvincible()
    /// Makes the ship temporarily invincible
    /// </summary>
    /// <returns>Handle to current coroutine</returns>
    IEnumerator BeInvincible()
    {
        info.isInvincible = true;
        //sprite.color = Color.blue;
        //mesh.
        yield return new WaitForSeconds(5f);
        //sprite.color = Color.white;
        info.isInvincible = false;
        yield return null;
    }
}