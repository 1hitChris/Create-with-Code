using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartThrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject heartPrefab;
    private AudioSource playerAudio;
    public AudioClip throwSound;

    public int maxHearts = 3;
    public int currentHearts;
    public int attackSpeed = 3;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        currentHearts = 0;
    }

    // Start is called before the first frame update
    void Update()
    {
        if (currentHearts <= 0)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            playerAudio.PlayOneShot(throwSound, 1.0f);
            Shoot();
            StartCoroutine(AttackSpeed());
        }
    }

    void Shoot()
    {
        Instantiate(heartPrefab, firePoint.position, firePoint.rotation);
        currentHearts--;
    }
    IEnumerator AttackSpeed()
    {
        yield return new WaitForSeconds(attackSpeed);
    }
}
