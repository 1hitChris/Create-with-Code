using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectionDown : MonoBehaviour
{
    public float affectionDown = -1f;
    private PlayerOneHealth affection;
    private PlayerTwoHealth affection2;
    public GameObject pickupEffect;
    private AudioSource playerAudio;
    public AudioClip pickUpSound;

    private void Start()
    {
        affection = GetComponent<PlayerOneHealth>();
        affection2 = GetComponent<PlayerTwoHealth>();
        playerAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
                PickUpP1(other);
        }
        if (other.CompareTag("Player2"))
        {
                PickUpP2(other);
        }
    }

    void PickUpP1(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        playerAudio.PlayOneShot(pickUpSound, 5f);
        PlayerOneHealth affectionReduction = player.GetComponent<PlayerOneHealth>();
        affectionReduction.TakeDamage(-1);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine("Wait");
    }
    void PickUpP2(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        playerAudio.PlayOneShot(pickUpSound, 5f);
        PlayerTwoHealth affectionReduction = player.GetComponent<PlayerTwoHealth>();
        affectionReduction.TakeDamage(-1);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }
}
