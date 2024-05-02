using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float upwardForce = 30f;
    public float rotationSpeed = 20f;
    public float forwardForce = 10f; // New variable for forward movement force
    public bool enableControl = true;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (enableControl)
        {
            // Apply upward force while Space key is pressed.
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * upwardForce * Time.deltaTime, ForceMode.Impulse);
            }

            // Rotate the rocket around its own Z-axis using left and right arrow keys.
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 rotation = new Vector3(0f, 0f, -horizontalInput * rotationSpeed);

            // Apply rotation based on the current orientation of the rocket.
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation * Time.deltaTime));

            // Calculate forward vector based on current rotation.
            Vector3 forwardDirection = rb.transform.up; // Using the up direction since the rocket is facing upwards.

            // Apply forward force in the calculated direction.
            rb.AddForce(forwardDirection * forwardForce * Time.deltaTime, ForceMode.Impulse);

            if (Input.GetKey(KeyCode.Tab))
            {
                transform.position = new Vector3(0f, 3.28f, 0f);
            }
        }
    }
}
