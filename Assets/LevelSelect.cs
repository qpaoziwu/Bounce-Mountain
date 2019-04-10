﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public int level;

    public void SelectLevel()
    {
        SceneManager.LoadScene(level);
    }
}
