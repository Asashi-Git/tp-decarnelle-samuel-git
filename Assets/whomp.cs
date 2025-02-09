using UnityEngine;

public class RockTrap : MonoBehaviour
{
    public Rigidbody rockRb;
    public Transform spawnPoint;
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name); // Debug message

        if (other.CompareTag("Player") && !activated)
        {
            Debug.Log("Player hit the cube! Restarting scene...");
            activated = true;
            rockRb.isKinematic = false;
        }
    }
}
