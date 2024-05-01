using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    private Transform target;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public float smoothSpeed = 0.125f;
    public float distanceFromSphere = 100.0f; // Adjust this value to control the distance

    public void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void SetCameraTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position as a fixed distance from the sphere's surface
            Vector3 directionToSphere = transform.position - target.position;
            Vector3 desiredPosition = target.position + directionToSphere.normalized * (target.localScale.x * 0.5f + distanceFromSphere); // Consider sphere's radius
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Calculate the center of the sphere
            Vector3 sphereCenter = target.position;

            // Calculate the new lookAt position as the center of the sphere
            Vector3 lookAtPosition = sphereCenter;

            // Rotate the camera to look at the center of the sphere
            transform.LookAt(lookAtPosition);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            target = null;
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}
