using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGameObjectsUpAndDownRandomly : MonoBehaviour
{
    public float maxUpDistance = 10.0f;
    public float maxDownDistance = 10.0f;
    public float moveSpeed = 2.0f;

    private Vector3 originalPosition;
    private float randomOffset;
    private float direction = 1.0f;

    private void Start()
    {
        originalPosition = transform.position;
        CalculateRandomOffset();
    }

    private void Update()
    {
        Vector3 newPosition = originalPosition + new Vector3(0f, randomOffset * direction, 0f);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, newPosition) < 0.01f)
        {
            CalculateRandomOffset();
            direction *= -1.0f;
        }
    }

    private void CalculateRandomOffset()
    {
        randomOffset = Random.Range(-maxDownDistance, maxUpDistance);
    }
}
