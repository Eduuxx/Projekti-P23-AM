using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float playerHeight = 2.1f;
    public float speed = 7f;

    public float gravity = -9.81f;
    public float jump = 1f;
    public bool isCrouching;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching)
            {
                isCrouching = false;
            }
            else {
                isCrouching = true;
            }
        }

        if (isCrouching) 
        {
            controller.height = (float)(playerHeight * 0.25);
            speed = (float)7 / 2;
        } 
        else {
            controller.height = playerHeight;
            speed = 7;
        }


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
