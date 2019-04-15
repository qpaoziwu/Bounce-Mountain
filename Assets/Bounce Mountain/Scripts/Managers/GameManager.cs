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

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    private GameObject statsManagerObject;
    private StatsManager statsManagerScript;
    private GameObject timeTrackerObject;
    private TimeTracker timeTrackerScript;
    private GameObject musicManagerObject;
    private GameObject musicManagerParent;

    // Start is called before the first frame update
    void Start()
    {
        checkpointsInLevel = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        checkpointsRemaining = checkpointsInLevel;
        currentScene = SceneManager.GetActiveScene();

        statsManagerObject = GameObject.FindGameObjectWithTag("StatsManager");
        if (statsManagerObject != null)
        {
            statsManagerScript = statsManagerObject.GetComponent<StatsManager>();
            statsManagerScript.SetStartScene();
        }

        timeTrackerObject = GameObject.FindGameObjectWithTag("TimeTracker");
        if (timeTrackerObject != null)
        {
            timeTrackerScript = timeTrackerObject.GetComponent<TimeTracker>();
            timeTrackerScript.SetStartScene();
        }

        musicManagerParent = GameObject.FindGameObjectWithTag("MusicManager");
        if (musicManagerParent != null)
        {
            musicManagerObject = FindMusicManager(musicManagerParent, "MainGameMusic");

            if (currentScene != SceneManager.GetSceneByBuildIndex(0))
            {
                musicManagerObject.SetActive(true);
            }
            else
            {
                musicManagerObject.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointsRemaining == 0 && currentScene.name != "sce_Main_Menu" &&
            Application.CanStreamedLevelBeLoaded(currentScene.buildIndex + 1))
        {
            if (timeTrackerObject != null)
            {

                timeTrackerScript.OnSceneRestart();
                SceneManager.LoadScene(currentScene.buildIndex);
            }
            else
            {
                if (statsManagerObject != null)
                {
                    statsManagerScript.SetHighScoreTime();
                }

                if (currentScene.name != "sce_Level_6")
                {
                    SceneManager.LoadScene(currentScene.buildIndex + 1);
                }

            }

        }
        else if (checkpointsRemaining == 0 && currentScene.name != "sce_Main_Menu" &&
        !Application.CanStreamedLevelBeLoaded(currentScene.buildIndex + 1))
        {
            if (statsManagerObject != null)
            {
                statsManagerScript.SetHighScoreTime();
            }
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && currentScene.name != "sce_Main_Menu")
        {
            if (gameIsPaused == true)
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

    public static GameObject FindMusicManager(GameObject parentObject, string name)
    {

        Transform[] childTransforms = parentObject.GetComponentsInChildren<Transform>(true);
        foreach (Transform trs in childTransforms)
        {
            if (trs.name == name)
            {
                return trs.gameObject;
            }
        }
        return null;

    }
}
