using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public CharacterController2DPlayer2 controller;
    public Animator animator;

    public float speed = 30.0f;

    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        // Get player movement
        horizontalMove = Input.GetAxisRaw("HorizontalP2") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Check if Jump button is pushed down and if it is, execute
        if (Input.GetButtonDown("JumpP2"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            Debug.Log("Jump");
        }
    }

    //Bool for checking if character is jumping or not. For animation purpose
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // Get the controller movement for character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
