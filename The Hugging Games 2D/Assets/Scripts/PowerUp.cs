using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 2f;
    public float powerUpDuration = 5;
    public GameObject pickupEffect;
    private AudioSource playerAudio;
    public AudioClip pickUpSound;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           StartCoroutine(PickUpP1(other));
        }
        if (other.CompareTag("Player2"))
        {
            StartCoroutine(PickUpP2(other));
        }
    }

    IEnumerator PickUpP1(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        playerAudio.PlayOneShot(pickUpSound, 5f);
        PlayerMovement speedUp = player.GetComponent<PlayerMovement>();
        speedUp.speed *= multiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSecondsRealtime(powerUpDuration);
        speedUp.speed /= multiplier;
        Destroy(gameObject);
    }
    IEnumerator PickUpP2(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        playerAudio.PlayOneShot(pickUpSound, 5f);
        Player2Movement speedUp = player.GetComponent<Player2Movement>();
        speedUp.speed *= multiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSecondsRealtime(powerUpDuration);
        speedUp.speed /= multiplier;
        Destroy(gameObject);
    }
}
