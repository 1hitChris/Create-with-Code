using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float xBounds = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // If an object goes past the players view in the game, remove that object
        if (transform.position.x == xBounds || transform.position.x == -xBounds)
        {
            Destroy(gameObject);
        }
    }
}
