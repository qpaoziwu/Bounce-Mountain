using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatsMenu : MonoBehaviour
{
    public GameObject[] levelTimes;
    public GameObject[] rankingCrown;
    public Sprite[] rankingCrownSprites = new Sprite[4];
    
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
                rankingCrown[i].GetComponent<Image>().sprite = rankingCrownSprites[0];
            }
            else if(StatsManagerScript.highScoreTime[i + 1] < StatsManagerScript.silverScoreTimes[i] && StatsManagerScript.highScoreTime[i + 1] != 0)
            {
                rankingCrown[i].GetComponent<Image>().sprite = rankingCrownSprites[1];
            }
            else if(StatsManagerScript.highScoreTime[i + 1] < StatsManagerScript.bronzeScoreTimes[i] && StatsManagerScript.highScoreTime[i + 1] != 0)
            {
                rankingCrown[i].GetComponent<Image>().sprite = rankingCrownSprites[2];
            }
            else
            {
                rankingCrown[i].GetComponent<Image>().sprite = rankingCrownSprites[3];
            }
        }
    }
}
