using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Checkpoint OnHitEvent;
    private int checkpointsInLevel;
    private int checkpointsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        checkpointsInLevel = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        checkpointsRemaining = checkpointsInLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkpointsRemaining == 0)
        {
            Debug.Log("Level Complete!");
        }
    }

    public void OnCheckpointHit()
    {
        checkpointsRemaining -= 1;
    }
}
