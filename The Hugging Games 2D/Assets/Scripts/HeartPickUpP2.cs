using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUpP2 : MonoBehaviour
{
    void Start()
    {

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
                heartThrowScript2.currentHearts++;
                Destroy(gameObject);
            }
        }
    }
}
