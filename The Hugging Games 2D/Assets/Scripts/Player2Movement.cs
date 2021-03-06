﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public CharacterController2DPlayer2 controller;
    public Animator animator;
    public float speed = 30.0f;
    public float boundary = 2f;
    float horizontalMove = 0f;
    bool jump = false;
    public GameObject landingFxPrefab;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // Get player movement
        horizontalMove = Input.GetAxisRaw("HorizontalP2") * speed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (transform.position.x < -boundary)
        {
            transform.position = new Vector3(-boundary, transform.position.y, transform.position.z);
        }

        if (transform.position.x > boundary)
        {
            transform.position = new Vector3(boundary, transform.position.y, transform.position.z);
        }

        // Check if Jump button is pushed down and if it is, execute
        if (Input.GetButtonDown("JumpP2"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    //Bool for checking if character has landed on ground. For animation purpose
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        if (transform.position.y < -0.2f && rb.velocity.y < 0)
        {
            Vector3 landingPos = new Vector3(transform.position.x + rb.velocity.x * Time.deltaTime * 3, -0.71f, 0);

            Instantiate(landingFxPrefab, landingPos, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        // Get the controller movement for character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
