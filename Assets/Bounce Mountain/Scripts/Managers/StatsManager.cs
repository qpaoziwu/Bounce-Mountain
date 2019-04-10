using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsManager : MonoBehaviour
{
    public float[] highScoreTime;
    public float currentLevelTime;
    float levelStartTime;
    Scene currentscene;

    public float[] goldScoreTimes;
    public float[] silverScoreTimes;
    public float[] bronzeScoreTimes;
    public RankingData rankingStats;
    

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StatsManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        highScoreTime = new float[SceneManager.sceneCountInBuildSettings];
        goldScoreTimes = rankingStats.goldScoreTimes;
        silverScoreTimes = rankingStats.silverScoreTimes;
        bronzeScoreTimes = rankingStats.bronzeScoreTimes;
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
