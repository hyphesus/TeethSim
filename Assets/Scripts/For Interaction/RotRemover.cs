using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private GameObject collidingObject;
    private Rigidbody collidingObjectRigidbody;
    private bool isStuck = false;
    private bool isInteracting = false;
    private Transform initialParent;
    private Vector3 interactionOffset;

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
        // Check if left mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (collidingObject != null)
            {
                isInteracting = true;
                isStuck = true;

                // Store the initial parent
                initialParent = collidingObject.transform.parent;

                // Calculate the interaction offset
                interactionOffset = collidingObject.transform.position - transform.position;

                // Set the new parent (this object)
                collidingObject.transform.SetParent(transform, true);

                Debug.Log("Object selected: " + collidingObject.name);
            }
        }
        // Check if left mouse button is released
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (isInteracting)
            {
                isStuck = false;
                isInteracting = false;
                if (collidingObject != null)
                {
                    Debug.Log("Object released: " + collidingObject.name);

                    // Restore the initial parent
                    collidingObject.transform.SetParent(initialParent, true);

                    // Clear the collidingObject reference after release
                    collidingObject = null;
                    collidingObjectRigidbody = null;
                }
            }
        }

        // If the object is stuck, update its position and rotation to follow the interaction object with offset
        if (isStuck && collidingObject != null)
        {
            collidingObject.transform.position = transform.position + interactionOffset;
            collidingObject.transform.rotation = transform.rotation;
        }
    }
}
