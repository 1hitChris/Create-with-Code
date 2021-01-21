using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] heartPickUp;
    private float spawnRangeX = 6.0f;
    private float spawnRangeYBottom = -2.3f;
    private float spawnRangeYTop = 3.2f;
    private float startDelay = 5;
    private float spawnInterval = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHeart", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void SpawnHeart()
    {
        // Randomly generates spawn position
        Vector3 spawnPos1 = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(spawnRangeYBottom, spawnRangeYTop));
        Instantiate(heartPickUp[0], spawnPos1, heartPickUp[0].transform.rotation);
    }
}
