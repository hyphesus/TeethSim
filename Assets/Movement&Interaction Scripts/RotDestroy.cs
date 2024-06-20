using UnityEngine;

public class DestroyOnInteraction : MonoBehaviour
{
    private GameObject collidingObject;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Rotten"
        if (collision.gameObject.CompareTag("ROT"))
        {
            collidingObject = collision.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Clear the reference when the object is no longer colliding
        if (collision.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    void Update()
    {
        // Check if the left mouse button is clicked and there's a colliding object
        if (collidingObject != null && Input.GetKey(KeyCode.K))
        {
            // Destroy the colliding object
            Destroy(collidingObject);
            Debug.Log("Destroyed object: " + collidingObject.name);

            // Clear the reference after destruction
            collidingObject = null;
        }
    }
}
