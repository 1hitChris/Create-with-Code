using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneHealth : MonoBehaviour
{
    public PlayerMovement movement;
    public int startingAffection = 0;
    public int currentAffection;
    public int maxAffection = 10;
    bool playerStunned = false;
    public int stunDuration = 3;
    public Healthbar healthBar;
    public GameObject heartBig;
    public WinScript winScript;


    void Start()
    {
        GameObject healthBarP1 = GameObject.Find("Healthbar P1");
        healthBar = healthBarP1.GetComponent<Healthbar>();
        heartBig = healthBarP1.transform.Find("HeartBig").gameObject;
        currentAffection = startingAffection;
        healthBar.SetMaxHealth(currentAffection);
        GameObject win2 = GameObject.Find("GameManager");
        winScript = win2.GetComponent<WinScript>();
    }

    public void TakeDamage(int damage)
    {
        //Increase the affection with the amount of damage the player takes
        { 
                currentAffection += damage;
                healthBar.SetHealth(currentAffection);
        }

        //If affection reaches 10, player gets "stunned" by love
        if (currentAffection == maxAffection)
        {
            playerStunned = true;
            movement.enabled = false;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            StartCoroutine("StunDuration");
            heartBig.SetActive(true);
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
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerStunned = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerStunned)
        {
            Debug.Log("Hugged");
            winScript.Player2Win();
            //Play hug animation
            //Zoom in
            //Wait 2 seconds
            //Win screen appear
        }
    }
}
