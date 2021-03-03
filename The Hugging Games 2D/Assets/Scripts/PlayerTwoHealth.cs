using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoHealth : MonoBehaviour
{
    public Player2Movement movement2;
    public Animator animator;
    private HeartThrowP2 heartThrow;
    public int startingAffection = 0;
    public int halfAffection = 5;
    public int currentAffection;
    public int maxAffection = 10;
    public bool playerStunned = false;
    public int stunDuration = 3;
    public GameManager gameManager;
    public Healthbar healthBar;
    public GameObject heartBig;
    private bool waiting = false;
    public WinScript winScript;
    private AudioSource playerAudio;
    public AudioClip stunSound;
    public AudioClip winSound;
    private PlayerOneHealth p1health;


    void Start()
    {
        GameObject healthBarP2 = GameObject.Find("Healthbar P2");
        healthBar = healthBarP2.GetComponent<Healthbar>();
        heartBig = healthBarP2.transform.Find("HeartBig").gameObject;
        currentAffection = startingAffection;
        healthBar.SetMaxHealth(currentAffection);
        GameObject win2 = GameObject.Find("GameManager");
        winScript = win2.GetComponent<WinScript>();
        playerAudio = GetComponent<AudioSource>();
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
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Stunned");
            StartCoroutine("StunDuration");
            heartBig.SetActive(true);
            animator.SetBool("IsStunned", true);
            playerAudio.PlayOneShot(stunSound, 1f);
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
        currentAffection = halfAffection;
        healthBar.SetHealth(currentAffection);
        heartBig.SetActive(false);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerStunned = false;
        animator.SetBool("IsStunned", false);
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
            movement2.enabled = false;

            //Play hug animation
            collision.gameObject.GetComponent<Animator>().SetTrigger("Hug");
            //Zoom in
            //Wait 2 seconds
            StartCoroutine("WinWait");
            //Win screen appear
        }
    }

    IEnumerator WinWait()
    {
        yield return new WaitForSecondsRealtime(1);
        winScript.Player1Win();
        playerAudio.PlayOneShot(winSound, 1f);
    }
}

