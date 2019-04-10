using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTracker : MonoBehaviour
{
    public float currentLevelTime;
    float levelStartTime;
    Scene currentscene;
    
    float timeAverage;
    public List<float> testTimes = new List<float>();

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("TimeTracker");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentscene.name != "sce_Main_Menu")
        {
            currentLevelTime = Time.time - levelStartTime;
        }
    }

    public void SetStartScene()
    {
        currentscene = SceneManager.GetActiveScene();
        levelStartTime = Time.time;
    }

    public void OnSceneRestart()
    {
        float timeAdded = 0;
        testTimes.Add(currentLevelTime);
        for (int i = 0; i < testTimes.Count; i++)
        {
            timeAdded += testTimes[i];
        }
        timeAverage = timeAdded / testTimes.Count;
        Debug.Log("Current Level Time: " + currentLevelTime + ", Average Level Time: " + timeAverage);
    }
}
