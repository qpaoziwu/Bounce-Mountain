﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Checkpoint OnHitEvent;
    private int checkpointsInLevel;
    private int checkpointsRemaining;
    private Scene currentScene;

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    private GameObject StatsManagerObject;
    private StatsManager StatsManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        checkpointsInLevel = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        checkpointsRemaining = checkpointsInLevel;
        currentScene = SceneManager.GetActiveScene();

        StatsManagerObject = GameObject.FindGameObjectWithTag("StatsManager");
        if (StatsManagerObject != null)
        {
            StatsManagerScript = StatsManagerObject.GetComponent<StatsManager>();
            StatsManagerScript.setStartScene();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointsRemaining == 0 && currentScene.name != "sce_Main_Menu" && 
            Application.CanStreamedLevelBeLoaded(currentScene.buildIndex + 1))
        {
            StatsManagerScript.setHighScoreTime();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && currentScene.name != "sce_Main_Menu")
        {
            if(gameIsPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
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

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }

    public void OnMainMenuButtonPressed()
    {
        Time.timeScale = 1.0f;
        gameIsPaused = false;
        SceneManager.LoadScene("sce_Main_Menu", LoadSceneMode.Single);
    }
}
