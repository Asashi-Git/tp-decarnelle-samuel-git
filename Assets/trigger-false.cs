using UnityEngine;

public class WhompTrap : MonoBehaviour
{
    // Reference to the Rigidbody component
    private Rigidbody rb;
    // Boolean flag to check if the trap has been activated
    private bool activated = false;

    private void Start()
    {
        // Try to get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        // If the Rigidbody component is missing, add one dynamically
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody was missing! Adding one now.", this);
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Set as kinematic so it does not move until activated
            rb.useGravity = true;   // Ensure gravity affects the object
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Log the name of the GameObject this object has collided with
        Debug.Log("Collided with: " + collision.gameObject.name);

        // Check if the colliding object is tagged as "Player" and the trap has not been activated yet
        if (collision.gameObject.CompareTag("Player") && !activated)
        {
            Debug.Log("Player is on the block! Enabling physics.");
            activated = true; // Set the trap as activated
            rb.isKinematic = false; // Allow physics simulation (falling, etc.)
        }
    }
}
