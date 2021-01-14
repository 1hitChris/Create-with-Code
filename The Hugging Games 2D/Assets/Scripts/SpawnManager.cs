using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] heartPickUp;
    private float spawnRangeX = 4.1f;
    private float spawnRangeYBottom = -2.3f;
    private float spawnRangeYTop = 3.1f;
    private float startDelay = 5;
    private float spawnInterval = 8;
    public int hearts = 0;
    public int maxHearts;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (maxHearts < 3)
        {
            InvokeRepeating("SpawnHeart", startDelay, spawnInterval);
        }
    }

    void SpawnHeart()
    {
        // Randomly generates spawn position

        if (hearts < 1)
        {
            Vector3 spawnPos1 = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(spawnRangeYBottom, spawnRangeYTop));
            Instantiate(heartPickUp[0], spawnPos1, heartPickUp[0].transform.rotation);
            hearts++;
        }
        if (maxHearts == 3)
        {
            CancelInvoke();
        }
       
    }
}
