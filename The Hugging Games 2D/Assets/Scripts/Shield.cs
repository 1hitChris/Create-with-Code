using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    private bool activeShield;
    public int shieldMaxHealth = 3;
    public int shieldCurrentHealth;
    public GameObject[] shieldSprites;
    private bool isShieldDestroyed;
    private PlayerOneHealth damage;

    // Start is called before the first frame update
    void Start()
    {
        damage.GetComponent<PlayerOneHealth>();
        shieldCurrentHealth = shieldMaxHealth;
        isShieldDestroyed = false;
        activeShield = false;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shield.SetActive(true);
            activeShield = true;
            ShieldAbsorb(shieldCurrentHealth);
        }
    }

    public void ShieldAbsorb(int damage)
    {
        {
            shieldCurrentHealth -= damage;
        }

        if (shieldCurrentHealth <= 0)
        {
            shield.SetActive(false);
            activeShield = false;
        }
       
    }
}
