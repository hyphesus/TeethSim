using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignWithHapticCollider : MonoBehaviour
{
    public Transform hapticColliderTrans;
    private Rigidbody rBody;
    public Vector3 correctionRotationEuler; // The correction rotation in Euler angles

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        if (rBody == null)
        {
            Debug.LogError("Rigidbody component not found.");
        }
    }

    void Update()
    {
        if (hapticColliderTrans == null || rBody == null)
        {
            return;
        }

        // Calculate the target rotation with an additional correction rotation
        Quaternion targetRotation = hapticColliderTrans.rotation * Quaternion.Euler(correctionRotationEuler);

        // Only update rotation if there's a significant difference
        if (Quaternion.Angle(rBody.rotation, targetRotation) > 0.1f) // Adjust the threshold as needed
        {
            rBody.rotation = targetRotation;
        }

        // Set velocity to zero to prevent spinning
        rBody.velocity = Vector3.zero;
        rBody.angularVelocity = Vector3.zero;
    }
}
