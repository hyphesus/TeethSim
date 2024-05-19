using UnityEngine;

public class StickyObject : MonoBehaviour
{
    private GameObject collidingObject;
    private Rigidbody collidingObjectRigidbody;
    private bool isStuck = false;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Rotten"
        if (collision.gameObject.CompareTag("Rotten"))
        {
            collidingObject = collision.gameObject;
            collidingObjectRigidbody = collidingObject.GetComponent<Rigidbody>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Clear the reference when the object is no longer colliding
        if (collision.gameObject == collidingObject)
        {
            collidingObject = null;
            collidingObjectRigidbody = null;
        }
    }

    void Update()
    {
        // Ensure collidingObject is not null before performing any operations
        if (collidingObject != null)
        {
            // Check if left mouse button is clicked
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Make the colliding object a child of this GameObject
                collidingObject.transform.SetParent(transform);
                Debug.Log("Object attached: " + collidingObject.name);
                isStuck = true;
            }
            // Check if left mouse button is released
            else if (Input.GetKeyUp(KeyCode.Mouse0) && isStuck)
            {
                // Detach the colliding object from this GameObject
                Transform originalParent = collidingObject.transform.parent;
                collidingObject.transform.SetParent(null);
                Debug.Log("Object detached: " + collidingObject.name);

                // Reset position and rotation in world space
                collidingObject.transform.position = transform.position;
                collidingObject.transform.rotation = transform.rotation;

                // Reset velocity and angular velocity
                collidingObjectRigidbody.velocity = Vector3.zero;
                collidingObjectRigidbody.angularVelocity = Vector3.zero;

                isStuck = false;
                collidingObject = null; // Reset collidingObject to prevent further null reference issues
                collidingObjectRigidbody = null; // Reset reference to the rigidbody
            }
        }
        else if (isStuck)
        {
            // If the object is no longer colliding and we think it's stuck, reset the state
            isStuck = false;
        }
    }
}
