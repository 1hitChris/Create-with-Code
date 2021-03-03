using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatImage : MonoBehaviour
{
    private Vector2 startPos;
    private float repeatwidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatwidth = GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatwidth)
        {
            transform.position = startPos;
        }
    }
}
