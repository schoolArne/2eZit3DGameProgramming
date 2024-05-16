using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobGameObjectUpAndDown : MonoBehaviour
{
    public float bobDistance = 1.0f; // Distance of bobbing motion
    public float bobSpeed = 1.0f;    // Speed of bobbing motion

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobDistance;
        transform.position = originalPosition + new Vector3(0f, yOffset, 0f);
    }
}
