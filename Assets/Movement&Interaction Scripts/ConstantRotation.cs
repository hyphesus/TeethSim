using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    // Rotation angle in degrees
    public float rotationAngleX = 90f;

    void Update()
    {
        // Apply rotation on the X axis
        transform.rotation = Quaternion.Euler(rotationAngleX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
