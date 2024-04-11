using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float smoothSpeed = 0.125f; // Adjust this to change how smoothly the camera follows
    public Vector3 offset; // Offset of the camera relative to the target

    void LateUpdate()
    {
        // Desired position with an offset
        Vector3 desiredPosition = target.position + offset;
        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Ensure the camera is always facing the target
        transform.LookAt(target);
    }
}
