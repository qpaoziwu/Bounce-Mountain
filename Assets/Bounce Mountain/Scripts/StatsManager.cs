using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsManager : MonoBehaviour
{
    public float[] highScoreTime;
    float currentLevelTime;
    float levelStartTime;
    Scene currentscene;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StatsManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        highScoreTime = new float[SceneManager.sceneCountInBuildSettings];
    }

    private void Update()
    {
        if(currentscene.name != "sce_Main_Menu")
        {
            currentLevelTime = Time.time - levelStartTime;
        }
    }


    public void setStartScene()
    {
        currentscene = SceneManager.GetActiveScene();
        levelStartTime = Time.time;
    }

    public void setHighScoreTime()
    {
        Debug.Log(currentscene.buildIndex);
        if(highScoreTime[currentscene.buildIndex] > currentLevelTime || highScoreTime[currentscene.buildIndex] == 0)
            highScoreTime[currentscene.buildIndex] = currentLevelTime;
        Debug.Log(highScoreTime[currentscene.buildIndex]);
    }
}
