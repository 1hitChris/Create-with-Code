﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene("Character Selection");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How to play");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
