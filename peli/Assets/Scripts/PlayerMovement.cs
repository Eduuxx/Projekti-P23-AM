using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;
    public bool isMoving;

    public float speed = 2f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;
    public float speedBoost = 1.5f;

    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale = new Vector3(1, 1f, 1);
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = crouchScale;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            speed -= 1f;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = playerScale;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            speed += 1f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed += speedBoost;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            speed -= speedBoost;

        if (Input.GetKeyDown("w"))
        {
            isMoving = true;
        }

        if (Input.GetKeyUp("w"))
        {
            isMoving = false;
        }
        if (Input.GetKeyDown("a"))
        {
            isMoving = true;
        }

        if (Input.GetKeyUp("a"))
        {
            isMoving = false;
        }
        if (Input.GetKeyDown("s"))
        {
            isMoving = true;
        }

        if (Input.GetKeyUp("s"))
        {
            isMoving = false;
        }
        if (Input.GetKeyDown("d"))
        {
            isMoving = true;
        }

        if (Input.GetKeyUp("d"))
        {
            isMoving = false;
        }
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

}
