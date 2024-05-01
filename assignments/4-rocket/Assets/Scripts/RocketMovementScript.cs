using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovementScript : MonoBehaviour
{
    public float upwardForce = 30f;
    public float rotationSpeed = 20f;
    public float forwardForce = 10f;
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
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * upwardForce * Time.deltaTime, ForceMode.Impulse);
            }
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 rotation = new Vector3(0f, 0f, -horizontalInput * rotationSpeed);
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation * Time.deltaTime));
            Vector3 forwardDirection = rb.transform.up;
            rb.AddForce(forwardDirection * forwardForce * Time.deltaTime, ForceMode.Impulse);
            if (Input.GetKey(KeyCode.R))
            {
                transform.position = new Vector3(0f, 3.28f, 0f);
            }
        }
    }
}
