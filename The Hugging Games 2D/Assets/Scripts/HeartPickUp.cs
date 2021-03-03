using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip pickUpSound;
    public GameObject heartPickUp;
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
                Instantiate(heartPickUp, transform.position, transform.rotation);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                playerAudio.PlayOneShot(pickUpSound, 5f);
                heartThrowScript.currentHearts++;
                StartCoroutine("Wait");
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }
}
