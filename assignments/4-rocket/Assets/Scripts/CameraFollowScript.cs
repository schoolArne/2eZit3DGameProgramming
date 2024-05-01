using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject objectToFollow;
    void Update()
    {
        transform.position = new Vector3(
            objectToFollow.transform.position.x,
            objectToFollow.transform.position.y,
            objectToFollow.transform.position.z + 3
        );
    }
}
