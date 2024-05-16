using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float xSpeed = 30f;
    public int maxXOffset = 21;

    void Update()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = horizontal * Time.deltaTime * xSpeed;
        float xNewPos = xOffset + transform.localPosition.x;
        transform.localPosition = new Vector3(Mathf.Clamp(xNewPos, -maxXOffset, maxXOffset), transform.localPosition.y, transform.localPosition.z);
    }
}
