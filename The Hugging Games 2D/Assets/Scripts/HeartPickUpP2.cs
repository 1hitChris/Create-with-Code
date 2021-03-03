using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUpP2 : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player2"))
        {
            HeartThrowP2 heartThrowScript2 = other.gameObject.GetComponent<HeartThrowP2>();

            if (heartThrowScript2.currentHearts == heartThrowScript2.maxHearts)
            {
                return;
            }
            else if (heartThrowScript2.currentHearts < heartThrowScript2.maxHearts)
            {
                Instantiate(heartPickUp, transform.position, transform.rotation);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                playerAudio.PlayOneShot(pickUpSound, 5f);
                heartThrowScript2.currentHearts++;
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
