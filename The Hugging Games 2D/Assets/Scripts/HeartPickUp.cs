using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    void Start()
    {
        
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
                heartThrowScript.currentHearts++;
                Destroy(gameObject);
            }
        }
    }
}
