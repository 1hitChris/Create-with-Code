using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private variables
    public float speed = 20.0f;
    public float turnSpeed = 75.0f;
    public float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get player input
        forwardInput = Input.GetAxis("Vertical");

        // We move the vehicle forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // We turn the vehicle
        transform.Rotate(Vector3.left, forwardInput * turnSpeed * Time.deltaTime);
    }
}
