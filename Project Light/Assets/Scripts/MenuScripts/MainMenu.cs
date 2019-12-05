﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Intro Scene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OpenTool()
    {
        SceneManager.LoadScene("HeatMap");
    }
}
