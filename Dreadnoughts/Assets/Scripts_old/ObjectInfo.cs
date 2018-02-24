using UnityEngine;

/// <summary>
/// Conner Catanese
/// ABSTRACT CLASS
/// Holds bounds references and on-collision action
/// </summary>
public abstract class ObjectInfo : MonoBehaviour
{
    // Public info
    public Vector3 center;
    public float radius;

    // Fields
    //internal SpriteRenderer sprite;
    internal MeshRenderer mesh;

    /// <summary>
    /// Start()
    /// Used for initialization
    /// </summary>
    internal void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
        mesh = GetComponent<MeshRenderer>();
        radius = 1f;
    }

    /// <summary>
    /// Update()
    /// Called once per frame
    /// </summary>
    internal void Update()
    {
        //center = sprite.bounds.center;
        center = mesh.bounds.center;
    }

    /// <summary>
    /// OnCollision()
    /// Object-specific on-collision action
    /// </summary>
    public abstract void OnCollision();
}