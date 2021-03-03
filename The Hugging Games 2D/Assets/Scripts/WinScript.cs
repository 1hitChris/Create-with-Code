using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject player1Wins;
    public GameObject player2Wins;
    public GameObject getReady;
    public GameObject hug;
    private Pause continueGame;
    private AudioSource playerAudio;
    public AudioClip winSound;
    private GameManager backgroundMusic;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    public void GetReady()
    {
        getReady.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine("GetReadyWaiting");
    }

    public void HugStarting()
    {
        hug.SetActive(true);
        StartCoroutine("HugWaiting");
    }
    public void Player1Win()
    {
        player1Wins.SetActive(true);
        playerAudio.Stop();
        playerAudio.PlayOneShot(winSound, 1f);
        Time.timeScale = 0;
    }

    public void Player2Win()
    {
        player2Wins.SetActive(true);
        playerAudio.Stop();
        playerAudio.PlayOneShot(winSound, 1f);
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void ContinueButton()
    {
        continueGame = GetComponent<Pause>();
        continueGame.ContinueGame();
        Time.timeScale = 1f;
    }

    IEnumerator GetReadyWaiting()
    {
        yield return new WaitForSecondsRealtime(3);
        getReady.SetActive(false);
        HugStarting();
    }
    IEnumerator HugWaiting()
    {
        yield return new WaitForSecondsRealtime(1);
        hug.SetActive(false);
        Time.timeScale = 1;
    }
}
