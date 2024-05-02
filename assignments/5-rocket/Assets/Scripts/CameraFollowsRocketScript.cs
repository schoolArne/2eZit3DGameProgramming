using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsRocketScript : MonoBehaviour
{
    public Transform targetObject; //rocket pos
    public float heightOffset = 5f;
    public bool enableCameraFollowing = true;
    private Vector3 initialPosition; //camera pos

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (enableCameraFollowing)
        {
            if (targetObject != null)
            {
                Vector3 targetPosition = targetObject.position;
                //X rocket, Y rocket + offset, Z camera
                Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y + heightOffset, initialPosition.z);
                transform.position = newPosition;
            }
        }        
    }
}
