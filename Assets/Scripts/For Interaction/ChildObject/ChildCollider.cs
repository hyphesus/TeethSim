using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour
{
    public LookAround cameraScript;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("objDef"))
        {
            // Calculate the impact force based on the collision
            Vector3 impactForce = collision.impulse / Time.fixedDeltaTime;

            // Apply the impact force to the camera's movement
            cameraScript.GetComponent<Rigidbody>().AddForce(impactForce, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("objDef"))
        {
            // Calculate the continuous impact force
            Vector3 impactForce = collision.impulse / Time.fixedDeltaTime;

            // Apply the impact force to the camera's movement
            cameraScript.GetComponent<Rigidbody>().AddForce(impactForce * Time.deltaTime, ForceMode.Force);
        }
    }
}
