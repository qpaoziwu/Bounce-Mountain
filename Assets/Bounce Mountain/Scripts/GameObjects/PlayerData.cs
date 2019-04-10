using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    //The value that the force applied to the object is multiplied by
    [Range(0.0f, 100.0f)]
    public float increaseForceMultiplier;

    //The value applied to the force of the object intended to reduce the force magnitude
    [Range(0.0f, 1.0f)]
    public float reduceForceMultiplier;

    //The physics material applied to the object
    public PhysicsMaterial2D objectPhysicsMaterial;

    //The colour applied to the object
    public Color objectColour;
}
