using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    bool playerHug = false;
    public GameObject hugEffect;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Hug();
        }
    }

    void Hug()
    {
        //Instantiate(hugEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
