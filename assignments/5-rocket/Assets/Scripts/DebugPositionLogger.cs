using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPositionLogger : MonoBehaviour
{
    public float logIntervalInSeconds = 1f; // Time interval for logging position (in seconds)
    public string objectName = "Object";
    public bool enableLogging = true;
    private float nextLogTime = 0f;

    void Update()
    {
        if (enableLogging)
        {
            if (Time.time >= nextLogTime)
            {
                Debug.Log($"{objectName} Position: {transform.position}");
                nextLogTime = Time.time + logIntervalInSeconds;
            }
        }
    }
}
