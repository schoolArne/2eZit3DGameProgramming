using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObjectScript : MonoBehaviour
{
    public CameraFollowScript cameraFollowScript; // Reference to the CameraFollowScript

    private void Start()
    {
        // Find the Main Camera in the scene and get its CameraFollowScript component
        cameraFollowScript = Camera.main.GetComponent<CameraFollowScript>();

        if (cameraFollowScript == null)
        {
            Debug.LogWarning("CameraFollowScript not found on the Main Camera!");
        }
    }

    private void OnMouseDown()
    {
        if (cameraFollowScript != null)
        {
            Debug.Log("Object Clicked: " + gameObject.name);
            cameraFollowScript.SetCameraTarget(transform);
        }
    }
}
