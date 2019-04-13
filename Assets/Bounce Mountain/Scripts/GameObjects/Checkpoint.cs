using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class OnHitEvent : UnityEvent { }

public class Checkpoint : MonoBehaviour
{
    public OnHitEvent OnHit = new OnHitEvent();
    private bool hit = false;

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player" && hit == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            OnHit.Invoke();
            hit = true;
        }
    }
}
