using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{

    public float gravity = -12f;
    public float jumpHeight = 3f;

    [SerializeField]
    private CharacterController controller;
    private Vector3 velocity;
    private float speed = 10f;
    private float sprintSpeed = 15f;
    private float jumpSpeed = 8f;
    private float sprintJumpSpeed = 10f;


    //For testing the player is on the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool isJumping = false;

    public ParticleSystem dirtParticule;
    public AudioClip jumpSound;
    private AudioSource playerAudio;


    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        if (GameManager.Instance.Colour != null)
        {
            GameObject playerCube = gameObject.transform.Find("PlayerCube").gameObject;
            playerCube.GetComponent<Renderer>().material.color = GameManager.Instance.Colour;
        }
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    // game puased
        //    Debug.Log("Game Paused");
        //    GameManager.Instance.PauseGame();   
        //}


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isJumping = false;          
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        bool pushRight = (Input.GetAxisRaw("Horizontal") > 0);
        float moveSpeed;
        var psMain = dirtParticule.main;

        if (pushRight && isGrounded)
        {
            moveSpeed = sprintSpeed;
            psMain.startSize = 0.75f ;
            psMain.startSpeed = 1f;
        }
        else
        {
            moveSpeed = speed;
            psMain.startSize = 0.45f;
            psMain.startSpeed = 0.2f;
        }

        if (!dirtParticule.isPlaying && isGrounded)
        {
            dirtParticule.Play();
        }

        controller.Move(forward * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = pushRight ? sprintJumpSpeed : jumpSpeed;
            isJumping = true;
            dirtParticule.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }


}