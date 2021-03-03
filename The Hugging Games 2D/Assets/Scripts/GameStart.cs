using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public WinScript getReady;
    private AudioSource playerAudio;
    public AudioClip announcer;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.PlayOneShot(announcer);
        GameObject start = GameObject.Find("GameManager");
        getReady = start.GetComponent<WinScript>();
        getReady.GetReady();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
