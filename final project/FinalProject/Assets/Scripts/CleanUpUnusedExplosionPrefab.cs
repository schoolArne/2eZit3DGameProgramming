using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpUnusedExplosionPrefab : MonoBehaviour
{
    void Start()
    {
        Invoke("Die", 1.0f);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
