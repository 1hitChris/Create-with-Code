using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoHealth : MonoBehaviour
{
    public Player2Movement movement2;
    public int startingAffection = 0;
    public int currentAffection;
    public int maxAffection = 10;
    bool playerStunned = false;
    public int stunDuration = 3;
    public GameManager gameManager;
    public Healthbar healthBar;
    public GameObject heartBig;
    private bool waiting = false;
    public WinScript winScript;

    void Start()
    {
        GameObject healthBarP2 = GameObject.Find("Healthbar P2");
        healthBar = healthBarP2.GetComponent<Healthbar>();
        heartBig = healthBarP2.transform.Find("HeartBig").gameObject;
        currentAffection = startingAffection;
        healthBar.SetMaxHealth(currentAffection);
        GameObject win2 = GameObject.Find("GameManager");
        winScript = win2.GetComponent<WinScript>();
    }

    private void Update()
    {
        
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
            movement2.enabled = false;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Debug.Log("Stunned");
            StartCoroutine("StunDuration");
            heartBig.SetActive(true);
           // StopTime(1.0f);
           // Destroy(gameObject);
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
        movement2.enabled = true;
        currentAffection = startingAffection;
        healthBar.SetHealth(currentAffection);
        heartBig.SetActive(false);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerStunned = false;
    }

    public void StopTime(float duration)
    {
        if (waiting == true)
        {
            return;
        }
        Time.timeScale = 0.1f;
        StartCoroutine(Wait(duration));
    }

    IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        waiting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerStunned)
        {
            Debug.Log("Hugged");
            winScript.Player1Win();
            //Play hug animation
            //Zoom in
            //Wait 2 seconds
            //Win screen appear
        }
    }
}

