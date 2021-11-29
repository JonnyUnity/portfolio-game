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
    private float sprintSpeed = 50f;
    private float jumpSpeed = 8f;


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
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        controller.Move(forward * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpSpeed;
            //isJumping = true;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
}
