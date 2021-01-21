using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    public AudioSource damageSource;
    public AudioClip damageSound;
    public float xBounds = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        damageSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // If an object goes past the players view in the game, remove that object
        if (transform.position.x > xBounds || transform.position.x < -xBounds)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            damageSource.PlayOneShot(damageSound, 1.0f);
        }
        Destroy(gameObject);
    }

}
