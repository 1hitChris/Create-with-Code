using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUpP2 : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip pickUpSound;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            HeartThrowP2 heartThrowScript2 = other.gameObject.GetComponent<HeartThrowP2>();

            if (heartThrowScript2.currentHearts == heartThrowScript2.maxHearts)
            {
                return;
            }
            else if (heartThrowScript2.currentHearts < heartThrowScript2.maxHearts)
            {
                playerAudio.PlayOneShot(pickUpSound, 1.0f);
                heartThrowScript2.currentHearts++;
                Destroy(gameObject);
            }
        }
    }
}
