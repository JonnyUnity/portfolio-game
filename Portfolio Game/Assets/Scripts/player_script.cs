using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [SerializeField]
    private CharacterController controller;
    private Vector3 velocity;
    private float speed = 10f;
    private float sprintSpeed = 15f;
    private float jumpSpeed = 8f;
    private float airSpeed;


    //For testing the player is on the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool isJumping = false;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isJumping = false;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        bool pushRight = (Input.GetAxisRaw("Horizontal") > 0);
        float moveSpeed;

        if (isJumping)
        {
            moveSpeed = airSpeed;
        }
        else if (pushRight)
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = speed;
        }
        
        controller.Move(forward * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpSpeed;
            isJumping = true;
            airSpeed = pushRight ? sprintSpeed : speed;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
}
