using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    public float delay = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }

}
