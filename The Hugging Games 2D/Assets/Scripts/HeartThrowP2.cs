using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartThrowP2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject heartPrefab;
    private AudioSource playerAudio;
    public AudioClip throwSound;
    public Animator animator;
    private PlayerTwoHealth p2Health;

    public int maxHearts = 3;
    public int currentHearts;
    public int attackSpeed = 3;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        p2Health = GetComponent<PlayerTwoHealth>();
        currentHearts = 0;
    }

    // Start is called before the first frame update
    void Update()
    {
        if (currentHearts <= 0 || p2Health.playerStunned == true)
        {
            return;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            playerAudio.PlayOneShot(throwSound, 1.0f);
            Shoot();
            animator.SetTrigger("Throw");
        }
    }

    public void Shoot()
    {
        Instantiate(heartPrefab, firePoint.position, firePoint.rotation);
        currentHearts--;
    }
    IEnumerator AttackSpeed()
    {
        yield return new WaitForSeconds(attackSpeed);
    }
}
