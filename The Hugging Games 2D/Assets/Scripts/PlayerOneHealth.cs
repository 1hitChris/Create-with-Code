using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneHealth : MonoBehaviour
{
    public PlayerMovement movement;
    public Animator animator;
    public int startingAffection = 0;
    public int currentAffection;
    public int halfAffection = 5;
    public int maxAffection = 10;
    public bool playerStunned = false;
    public bool playerHugging = false;
    public int stunDuration = 3;
    public Healthbar healthBar;
    public GameObject heartBig;
    public WinScript winScript;
    private AudioSource playerAudio;
    public AudioClip stunSound;
    public AudioClip winSound;


    void Start()
    {
        GameObject healthBarP1 = GameObject.Find("Healthbar P1");
        healthBar = healthBarP1.GetComponent<Healthbar>();
        heartBig = healthBarP1.transform.Find("HeartBig").gameObject;
        currentAffection = startingAffection;
        healthBar.SetMaxHealth(currentAffection);
        GameObject win2 = GameObject.Find("GameManager");
        winScript = win2.GetComponent<WinScript>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
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
            animator.SetBool("IsStunned", true);
            playerAudio.PlayOneShot(stunSound, 1f);
        }
    }
    IEnumerator StunDuration()
    {
        yield return new WaitForSeconds(stunDuration);
        movement.enabled = true;
        currentAffection = halfAffection;
        healthBar.SetHealth(currentAffection);
        heartBig.SetActive(false);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerStunned = false;
        animator.SetBool("IsStunned", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerStunned)
        {
            Debug.Log("Hugged");
            movement.enabled = false;
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
        winScript.Player2Win();
        playerAudio.PlayOneShot(winSound, 1f);
    }
}
