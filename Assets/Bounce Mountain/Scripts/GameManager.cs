using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Checkpoint OnHitEvent;
    private int checkpointsInLevel;
    private int checkpointsRemaining;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        checkpointsInLevel = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        checkpointsRemaining = checkpointsInLevel;
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointsRemaining == 0 && currentScene.name != "sce_Main_Menu")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OnCheckpointHit()
    {
        checkpointsRemaining -= 1;
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("sce_Level_1", LoadSceneMode.Single);
    }
}
