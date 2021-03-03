using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartThrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject heartPrefab;
    private AudioSource playerAudio;
    public AudioClip throwSound;
    public Animator animator;
    public int maxHearts = 3;
    public int currentHearts;
    public int attackSpeed = 3;
    private PlayerOneHealth p1Health;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        p1Health = GetComponent<PlayerOneHealth>();
        currentHearts = 0;
    }

    // Start is called before the first frame update
    void Update()
    {
        if (currentHearts <= 0 || p1Health.playerStunned == true)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("FireControllerButton"))
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
    IEnumerator AttackSpeed(float attackSpeed)
    {
        yield return new WaitForSeconds(attackSpeed);

    }
}
