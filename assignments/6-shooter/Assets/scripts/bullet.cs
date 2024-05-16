using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletLifeTimeInSeconds = 3.0f;

    void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(bulletLifeTimeInSeconds);
        Destroy(gameObject);
    }
}
