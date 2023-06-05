using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Public
    public Transform player;
    public float mouseSensitivity = 2f;

    // Private
    private float minTurnAngle = -90.0f;
    private float maxTurnAngle = 90.0f;
    private float rotX; // vertical

    void Start()
    {
        // Lock and Hide the Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotX += Input.GetAxis("Mouse Y") * mouseSensitivity;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }
}
