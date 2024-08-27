using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatedEnemyItem : MonoBehaviour
{
    private float rotationSpeed = 100f;
    private float bobbingAmplitude = 0.5f;
    private float bobbingSpeed = 2f;
    private float initialY;
    void Start()
    {
        initialY = transform.position.y;
    }
    void Update()
    {
        Spin();
        Bob();
    }
    void Spin()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    void Bob()
    {
        float newY = initialY + Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
