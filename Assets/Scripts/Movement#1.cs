using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower3D : MonoBehaviour
{
    public float speed = 10f; // Speed at which the object moves
    public float zSpeed = 5f; // Speed for moving along the Z-axis

    private Camera mainCamera; // Main camera in the scene

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera
    }

    void Update()
    {
        // Convert mouse position to a ray
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Check if the ray hits any collider in the scene
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Move the object towards the hit point on the X and Y
            Vector3 targetPosition = new Vector3(hit.point.x, hit.point.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        // Adjust the Z position using Shift and Control
        float zChange = 0;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            zChange = zSpeed; // Move outwards
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            zChange = -zSpeed; // Move inwards
        }

        // Apply the Z movement
        transform.position += new Vector3(0, 0, zChange * Time.deltaTime);
    }
}
