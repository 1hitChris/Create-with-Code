using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseGame;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        pauseGame.SetActive(true);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        pauseGame.SetActive(false);
        Time.timeScale = 1;
    }
}
