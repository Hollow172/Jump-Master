using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Transform groundCheckTransform = null;
    [SerializeField] LayerMask playerMask; 
    [SerializeField] Transform respawn;
    [SerializeField] GameObject DeathScreen;

    bool jumpKeyWasPressed;
    bool sprintON = false;
    int timesSpacePressed = 0;
    float canJump = 0f;
    Animator animator;
    bool isLookingRight = true;
    bool isLookingLeft = false;
    bool isMoving = false;

    public static bool superJumps = false;
    public static bool doubleJumps = false;
    public static float horizontalInput;
    public static Rigidbody rigidbodyComponent;
    public static float runSpeedMultiplier = 1.9f;
    public static int health;
    public static float jumpPower = 6f;

    // Initial coditions - health, rigidbody, animator and timescale
    void Start()
    {
        health = 3;
        rigidbodyComponent = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        //Checking pressed buttons used in movement:

        // Check if space key is pressed down (when double jumps are turned on)
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canJump && doubleJumps)
        {
            if (doubleJumps == true) timesSpacePressed += 1;
            jumpKeyWasPressed = true;
            canJump = Time.time + 0.4f;
        }
        // Check if space key is pressed down (when super jums are turned on)
        if (Input.GetKeyDown(KeyCode.Space) && superJumps && IsGrounded())
        {
            jumpKeyWasPressed = true;
        }
        // Check if space key is pressed down for normal jumps
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpKeyWasPressed = true;
        }
        //Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            runSpeedMultiplier = 2.4f;
            sprintON = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runSpeedMultiplier = 1.9f;
            sprintON = false;
        }
        //Movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            isMoving = false;
        }

        // Getting the axis for movement to left and right
        horizontalInput = Input.GetAxis("Horizontal");

        //Makes character fall faster
        if(rigidbodyComponent.velocity.y < 0)
        {
            rigidbodyComponent.velocity += Vector3.up * Physics.gravity.y * (1.2f) * Time.deltaTime;
        }

        //Setting animations:
        animator.SetBool("isJumping", !IsGrounded());
        animator.SetBool("isRunning",  IsGrounded() && sprintON == false && isMoving == true && SecretSign.isSleeping != true);
        animator.SetBool("isSprinting", IsGrounded() && sprintON == true && isMoving == true && SecretSign.isSleeping != true);

    }

    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        // Moving to left and right
        rigidbodyComponent.velocity = new Vector3(horizontalInput * runSpeedMultiplier, rigidbodyComponent.velocity.y, 0);
        if (rigidbodyComponent.velocity.x > 0 && isLookingLeft && SecretSign.isSleeping != true)
        {
            transform.Rotate(0f, 180f, 0f);
            isLookingRight = true;
            isLookingLeft = false;
        }
        if (rigidbodyComponent.velocity.x < 0 && isLookingRight && SecretSign.isSleeping != true)
        {
            transform.Rotate(0f, 180f, 0f);
            isLookingLeft = true;
            isLookingRight = false;
        }


        // Jumping
        if (jumpKeyWasPressed)
        {
            if (superJumps)
            {
                jumpPower = 9f;
                superJumps = false;
            }
            if (doubleJumps)
            {
                //Debug.Log(timesSpacePressed);
                rigidbodyComponent.velocity = new Vector3(horizontalInput * runSpeedMultiplier, jumpPower, 0);
                jumpPower = 6f;
                jumpKeyWasPressed = false;
                if (timesSpacePressed >= 2)
                {
                    doubleJumps = false;
                    timesSpacePressed = 0;
                }
            }
            else
            {
                if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
                {
                    return;
                }
                rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                jumpPower = 6f;
                jumpKeyWasPressed = false;
            }
        }
    }

    //Checking if player is in the air or on the ground by an object added to player
    private bool IsGrounded()
    {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }


}
