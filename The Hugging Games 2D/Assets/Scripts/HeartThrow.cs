using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartThrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject heartPrefab;
    private AudioSource playerAudio;
    public AudioClip throwSound;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAudio.PlayOneShot(throwSound, 1.0f);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(heartPrefab, firePoint.position, firePoint.rotation);
    }
}
