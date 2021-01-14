using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject spawnManager = GameObject.Find("SpawnManager");
        SpawnManager spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
        spawnManagerScript.hearts--;
        Destroy(gameObject);
        spawnManagerScript.maxHearts++;
        
    }
}
