using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] heartPickUp;
    public GameObject[] speedPickUp;
    public GameObject[] affectionDown;
    private float spawnRangeX = 2f;
    private float spawnRangeYBottom = -0.86f;
    private float spawnRangeYTop = 0.66f;
    private float startDelay = 5;
    private float spawnInterval = 5;
    private float shieldStartDelay;
    private float shieldInterval;
    private float controllerDelay;
    private float controllerInterval;

    // Start is called before the first frame update
    void Start()
    {
        shieldStartDelay = Random.Range(10, 35);
        shieldInterval = Random.Range(20, 45);
        controllerDelay = Random.Range(15, 40);
        controllerInterval = Random.Range(25, 50);
        InvokeRepeating("SpawnHeart", startDelay, spawnInterval);
        InvokeRepeating("SpawnShield", shieldStartDelay, shieldInterval);
        InvokeRepeating("SpawnController", controllerDelay, controllerInterval);
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

    void SpawnShield()
    {
        // Randomly generates spawn position
        Vector3 spawnPos1 = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(spawnRangeYBottom, spawnRangeYTop));
        Instantiate(speedPickUp[0], spawnPos1, speedPickUp[0].transform.rotation);
    }

    void SpawnController()
    {
        // Randomly generates spawn position
        Vector3 spawnPos1 = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(spawnRangeYBottom, spawnRangeYTop));
        Instantiate(affectionDown[0], spawnPos1, affectionDown[0].transform.rotation);
    }
}
