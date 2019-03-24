using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBooster : MonoBehaviour
{
    [Range(0.0f, 50.0f)] public float boostAmount; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.attachedRigidbody.AddForce(boostAmount * other.attachedRigidbody.velocity, ForceMode2D.Impulse);
        }

    }
}
