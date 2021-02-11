using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hug : MonoBehaviour
{
    public int damage = 1;

    void OnCollision2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerOneHealth health = hitInfo.GetComponent<PlayerOneHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("Hugged");
            }
            Destroy(gameObject);
        }
        else if (hitInfo.gameObject.CompareTag("Player2"))
        {
            PlayerTwoHealth health = hitInfo.GetComponent<PlayerTwoHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("Hugged");
            }
            Destroy(gameObject);
        }

    }
}
