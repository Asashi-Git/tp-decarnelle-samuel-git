using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    // WheelColliders to simulate the car's wheels physics
    public WheelCollider frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel;

    // Transforms to visually update wheel position and rotation
    public Transform frontLeftTransform, frontRightTransform, rearLeftTransform, rearRightTransform;

    // Maximum torque applied to rear wheels for acceleration
    public float maxTorque = 1500f;

    // Maximum angle the front wheels can steer
    public float maxSteeringAngle = 30f;

    // Speed multiplier for different speed settings
    public float speedMultiplier = 1f;

    private void FixedUpdate()
    {
        // Get input from Vertical axis (W/S or Up/Down keys) for acceleration/braking
        float acceleration = Input.GetAxis("Vertical") * maxTorque * speedMultiplier;

        // Get input from Horizontal axis (A/D or Left/Right keys) for steering
        float steering = Input.GetAxis("Horizontal") * maxSteeringAngle;

        // Apply acceleration to the rear wheels
        ApplyAcceleration(acceleration);

        // Apply steering to the front wheels
        ApplySteering(steering);

        // Update the position and rotation of the wheel meshes
        UpdateWheelTransforms();
    }

    // Method to apply acceleration to the rear wheels
    void ApplyAcceleration(float acceleration)
    {
        rearLeftWheel.motorTorque = acceleration;
        rearRightWheel.motorTorque = acceleration;
    }

    // Method to apply steering to the front wheels
    void ApplySteering(float steering)
    {
        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;
    }

    // Method to update all wheel transforms based on physics simulation
    void UpdateWheelTransforms()
    {
        UpdateWheelTransform(frontLeftWheel, frontLeftTransform);
        UpdateWheelTransform(frontRightWheel, frontRightTransform);
        UpdateWheelTransform(rearLeftWheel, rearLeftTransform);
        UpdateWheelTransform(rearRightWheel, rearRightTransform);
    }

    // Method to update a single wheel's position and rotation
    void UpdateWheelTransform(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        // Get the world position and rotation from the WheelCollider
        collider.GetWorldPose(out pos, out rot);

        // Apply the position from the WheelCollider to the wheel Transform
        wheelTransform.position = pos;

        // Apply the full rotation from the WheelCollider to the wheel Transform
        wheelTransform.rotation = rot;
    }

    // Method to set speed multiplier from UI or input
    public void SetSpeed(float multiplier)
    {
        speedMultiplier = multiplier;
    }
}