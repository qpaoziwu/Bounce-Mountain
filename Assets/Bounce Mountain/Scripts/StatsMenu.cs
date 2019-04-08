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
        }
    }

}
