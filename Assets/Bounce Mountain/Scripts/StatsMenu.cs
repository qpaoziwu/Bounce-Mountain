using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StatsMenu : MonoBehaviour
{
    public GameObject[] levelTimes;
    GameObject StatsManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        StatsManager StatsManagerScript = GameObject.FindGameObjectWithTag("StatsManager").GetComponent<StatsManager>();
        for (int i = 0; i < levelTimes.Length; i++)
        {
            levelTimes[i].GetComponent<TextMeshProUGUI>().text = "Level " + (i + 1) + ":       " + StatsManagerScript.highScoreTime[i + 1] + " s";
            if(StatsManagerScript.highScoreTime[i+1] < StatsManagerScript.goldScoreTimes[i] && StatsManagerScript.highScoreTime[i + 1] != 0)
            {
                //Display Gold
                Debug.Log((i+1) + "Got Gold");
            }
            else if(StatsManagerScript.highScoreTime[i + 1] < StatsManagerScript.silverScoreTimes[i] && StatsManagerScript.highScoreTime[i + 1] != 0)
            {
                //Display Silver
                Debug.Log((i+1) + "Got Silver");
            }
            else if(StatsManagerScript.highScoreTime[i + 1] < StatsManagerScript.bronzeScoreTimes[i] && StatsManagerScript.highScoreTime[i + 1] != 0)
            {
                //Display Bronze
                Debug.Log((i+1) + "Got Bronze");
            }
            else
            {
                //Display empty metal
                Debug.Log((i+1) + "Got Nothing");
            }
        }
    }
}
