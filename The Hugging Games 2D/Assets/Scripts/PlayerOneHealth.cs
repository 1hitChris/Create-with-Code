using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneHealth : MonoBehaviour
{
    public PlayerMovement movement;
    public int startingAffection = 0;
    public int currentAffection;
    public int maxAffection = 10;
    bool playerHug = false;
    //public GameObject hugEffect;
    bool playerStunned = false;
    public int stunDuration = 3;
    public Healthbar healthBar;
    public GameObject heartBig;

    void Start()
    {
        GameObject healthBarP1 = GameObject.Find("Healthbar P1");
        healthBar = healthBarP1.GetComponent<Healthbar>();
        heartBig = healthBarP1.transform.Find("HeartBig").gameObject;
        currentAffection = startingAffection;
        healthBar.SetMaxHealth(currentAffection);
    }

    public void TakeDamage(int damage)
    {
        //Increase the affection with the amount of damage the player takes
        currentAffection += damage;
        healthBar.SetHealth(currentAffection);

        //If affection reaches 10, player gets "stunned" by love
        if (currentAffection == maxAffection)
        {
            playerStunned = true;
            movement.enabled = false;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Stunned");
            StartCoroutine("StunDuration");
            heartBig.SetActive(true);
            Destroy(gameObject);
        }
    }

    void Win()
    {
        if (playerStunned == true)
        {
            //Instantiate(hugEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

            //Stops time when player wins
            Time.timeScale = 0;
        }
    }
    IEnumerator StunDuration()
    {
        yield return new WaitForSeconds(stunDuration);
        movement.enabled = true;
        currentAffection = startingAffection;
        healthBar.SetHealth(currentAffection);
        heartBig.SetActive(false);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
    }
}
