using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectionDown : MonoBehaviour
{
    public float affectionDown = -1f;
    private PlayerOneHealth affection;
    private PlayerTwoHealth affection2;

    private void Start()
    {
        affection = GetComponent<PlayerOneHealth>();
        affection2 = GetComponent<PlayerTwoHealth>();
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
        PlayerOneHealth affectionReduction = player.GetComponent<PlayerOneHealth>();
        affectionReduction.TakeDamage(-1);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }
    void PickUpP2(Collider2D player)
    {
        PlayerTwoHealth affectionReduction = player.GetComponent<PlayerTwoHealth>();
        affectionReduction.TakeDamage(-1);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }
}
