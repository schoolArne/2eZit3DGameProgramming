using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSphere : MonoBehaviour
{
    public int amountOfPoints = 1;

    private RocketPointsCounter[] rocketPointsCounterScripts;
    private bool run = true;

    private void Start()
    {
        rocketPointsCounterScripts = GameObject.FindObjectsOfType<RocketPointsCounter>();
        if (rocketPointsCounterScripts.Length != 1)
        {
            run = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (run)
        {
            if (rocketPointsCounterScripts.Length > 0)
            {
                rocketPointsCounterScripts[0].IncreasePoints(amountOfPoints);
            }
            else
            {
                Debug.LogWarning("RocketPointsCounter array is empty.");
            }
        }
        else
        {
            Debug.LogWarning("multiple or no RocketPointsCounter scripts found so method did not execute");
        }
        Destroy(gameObject);
    }
}
