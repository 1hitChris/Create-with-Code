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
    public float spin = 4f;

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

        transform.Rotate(new Vector3(0,0,-720) * spin * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerOneHealth health = hitInfo.GetComponent<PlayerOneHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                damageSource.PlayOneShot(damageSound, 1.0f);
            }
            Destroy(gameObject);
        }
        else if (hitInfo.gameObject.CompareTag("Player2"))
        {
            PlayerTwoHealth health = hitInfo.GetComponent<PlayerTwoHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                damageSource.PlayOneShot(damageSound, 1.0f);
            }
            Destroy(gameObject);
        }
            
    }

}
