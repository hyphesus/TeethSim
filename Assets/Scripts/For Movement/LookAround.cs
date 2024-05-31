using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 5.0f;
    public float speed = 5.0f;
    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the camera forward, backward, left, and right
        Vector3 moveDirection = transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        moveDirection += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Add vertical movement based on the Ctrl and Shift keys
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            moveDirection += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveDirection += Vector3.up * speed * Time.deltaTime;
        }

        // Apply the calculated movement to the camera
        transform.position += moveDirection;

        // Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);
    }
}
