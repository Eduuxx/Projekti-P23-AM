using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Entity playerEntity;

    private bool isGrounded;
    private bool isCrouching = false;
    private float maxYVelocity;

    public float currentSpeed = 4f;
    public float walkSpeed = 4f;
    public float crouchSpeed = 1f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;
    public float runningSpeedBoost = 1.5f;

    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale = new Vector3(1, 1f, 1);

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerEntity = GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            transform.localScale = crouchScale;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            currentSpeed -= crouchSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            transform.localScale = playerScale;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            currentSpeed += crouchSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
            currentSpeed = crouchSpeed;
        else if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = walkSpeed + (runningSpeedBoost / 2);
        else if (isCrouching)
            currentSpeed = crouchSpeed;
        else
            currentSpeed = 4f;

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");

        controller.Move(transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime); // WASD triggered movement

        playerVelocity.y += gravity * Time.deltaTime;

        if (!isGrounded)
        {
            maxYVelocity = playerVelocity.y < maxYVelocity ? playerVelocity.y : maxYVelocity; // Always change value to the lowest velocity, so it can be checked against later
        }

        if (isGrounded && Input.GetKey("space")) {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            maxYVelocity = -2f; // Reset velocity before new jumps
        }

        if (isGrounded && playerVelocity.y < 0)
        {
            if (maxYVelocity < -7f)
            {
                // Apply fall damage
                playerEntity.takeDamage(20);
            }
            playerVelocity.y = -2f;
            maxYVelocity = playerVelocity.y; // Reset velocity when on ground

        }
        controller.Move(playerVelocity * Time.deltaTime); // Gravity movement
    }
}
}