using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip pickUpSound;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HeartThrow heartThrowScript = other.gameObject.GetComponent<HeartThrow>();
            
            if (heartThrowScript.currentHearts == heartThrowScript.maxHearts)
            {
                return;
            }
            else if (heartThrowScript.currentHearts < heartThrowScript.maxHearts)
            {
                playerAudio.PlayOneShot(pickUpSound, 1.0f);
                heartThrowScript.currentHearts++;
                Destroy(gameObject);
            }
        }
    }
}
