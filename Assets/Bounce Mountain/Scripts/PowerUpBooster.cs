using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBooster : MonoBehaviour
{
    [Range(0.0f, 100.0f)] public float boostAmount;

    //Dropdown menu for booster direction in inspector
    public enum BoosterDirection { None, Up, Right, Down, Left }
    public BoosterDirection boosterDirection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If "None" is selected for booster direction
        if (boosterDirection == BoosterDirection.None)
        {
            if (other.gameObject.tag == "Player")
            {
                other.attachedRigidbody.AddForce(boostAmount * other.attachedRigidbody.velocity, ForceMode2D.Impulse);
            }
        }

        //If "Up" is selected for booster direction
        if (boosterDirection == BoosterDirection.Up)
        {
            if (other.gameObject.tag == "Player")
            {
                other.attachedRigidbody.AddForce(Vector2.up * boostAmount + other.attachedRigidbody.velocity, ForceMode2D.Impulse);
            }
        }

        //If "Right" is selected for booster direction
        if (boosterDirection == BoosterDirection.Right)
        {
            if (other.gameObject.tag == "Player")
            {
                other.attachedRigidbody.AddForce(Vector2.right * boostAmount + other.attachedRigidbody.velocity, ForceMode2D.Impulse);
            }
        }

        //If "Down" is selected for booster direction
        if (boosterDirection == BoosterDirection.Down)
        {
            if (other.gameObject.tag == "Player")
            {
                other.attachedRigidbody.AddForce(Vector2.down * boostAmount + other.attachedRigidbody.velocity, ForceMode2D.Impulse);
            }
        }

        //If "Left" is selected for booster direction
        if (boosterDirection == BoosterDirection.Left)
        {
            if (other.gameObject.tag == "Player")
            {
                other.attachedRigidbody.AddForce(Vector2.left * boostAmount + other.attachedRigidbody.velocity, ForceMode2D.Impulse);
            }
        }
    }
}
