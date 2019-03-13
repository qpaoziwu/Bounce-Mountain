using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public int checkpointNumber;
    public Text checkpointTimeText;
    private float timeFromStart;
    private float checkpointReachedTime;

    // Update is called once per frame
    void Update()
    {
        timeFromStart = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.GetComponent<PlayerController>().currentCheckPoint == checkpointNumber - 1)
        {
            checkpointReachedTime = timeFromStart - trigger.GetComponent<PlayerController>().lastCheckpointTime;

            checkpointTimeText.text = "Checkpoint " + checkpointNumber + ": " + checkpointReachedTime;            
            trigger.GetComponent<PlayerController>().lastCheckpointTime += checkpointReachedTime;
            trigger.GetComponent<PlayerController>().currentCheckPoint = checkpointNumber;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
    }
}
