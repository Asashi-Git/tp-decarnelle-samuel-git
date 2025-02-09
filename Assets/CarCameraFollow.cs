using UnityEngine;

// This script makes the camera smoothly follow a target object (like a car)
public class CarCameraFollow : MonoBehaviour
{
    // The target object the camera will follow
    public Transform target;

    // Offset position of the camera relative to the target
    public Vector3 offset;

    // Speed at which the camera follows the target smoothly
    public float smoothSpeed = 5f;

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // Compute the desired position of the camera
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the current position and the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Make the camera look at the target
        transform.LookAt(target);
    }
}