using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public GameObject pauseGame;
    private AudioSource playerAudio;
    public AudioClip pauseSound;
    public AudioClip unpauseSound;
    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

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
        playerAudio.Stop();
        playerAudio.PlayOneShot(pauseSound, 1f);
        Time.timeScale = 0;

        //Clear slected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set new selected object
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }
    public void ContinueGame()
    {
        pauseGame.SetActive(false);
        playerAudio.PlayOneShot(unpauseSound, 1f);
        playerAudio.Play();
        Time.timeScale = 1f;
    }
}
