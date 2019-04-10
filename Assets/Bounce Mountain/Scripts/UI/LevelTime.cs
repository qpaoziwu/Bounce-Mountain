using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTime : MonoBehaviour
{
    GameObject statsManagerObject;
    StatsManager statsManagerScript;
    TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();

        statsManagerObject = GameObject.FindGameObjectWithTag("StatsManager");
        if(statsManagerObject != null)
        {
            statsManagerScript = statsManagerObject.GetComponent<StatsManager>();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = statsManagerScript.currentLevelTime.ToString("F2");
    }
}
