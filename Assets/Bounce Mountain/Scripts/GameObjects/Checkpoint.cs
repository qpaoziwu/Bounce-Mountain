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

    /* Checkpoint time code - removed due to being obsolete
    public int checkpointNumber;
    public Text checkpointTimeText;
    private float timeFromStart;
    private float checkpointReachedTime;

    
    // Update is called once per frame
    void Update()
    {
        timeFromStart = Time.time;
    }
    */

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player" && hit == false)
        {
            //if (trigger.GetComponent<PlayerController>().currentCheckPoint == checkpointNumber - 1)
            //{
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            OnHit.Invoke();
            Debug.Log("OnHit invoked!");
            hit = true;

            /* Checkpoint time code - removed due to being obsolete
            checkpointReachedTime = timeFromStart - trigger.GetComponent<PlayerController>().lastCheckpointTime;

            if (checkpointTimeText != null)
            {
                checkpointTimeText.text = "Checkpoint " + checkpointNumber + ": " + checkpointReachedTime;
            }

            trigger.GetComponent<PlayerController>().lastCheckpointTime += checkpointReachedTime;
            trigger.GetComponent<PlayerController>().currentCheckPoint = checkpointNumber;
            */
            //}
        }
    }
}
