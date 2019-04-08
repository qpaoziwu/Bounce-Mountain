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
            levelTimes[i].GetComponent<TextMeshProUGUI>().text = "Level " + (i + 1) + ": " + StatsManagerScript.highScoreTime[i + 1] + " s";
            if(StatsManagerScript.highScoreTime[i+1] < StatsManagerScript.goldScoreTimes[i])
            {
                //Display Gold
                Debug.Log(i + "Got Gold");
            }
            else if(StatsManagerScript.highScoreTime[i + 1] < StatsManagerScript.silverScoreTimes[i])
            {
                //Display Silver
                Debug.Log(i + "Got Silver");
            }
            else if(StatsManagerScript.highScoreTime[i + 1] < StatsManagerScript.bronzeScoreTimes[i])
            {
                //Display Bronze
                Debug.Log(i + "Got Bronze");
            }
            else
            {
                //Display empty metal
                Debug.Log(i + "Got Nothing");
            }
        }
    }
}
