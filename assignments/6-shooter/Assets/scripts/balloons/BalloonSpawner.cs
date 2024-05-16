using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BalloonSpawnInfo
{
    public GameObject balloonPrefab;
    [Range(0f, 1f)]
    public float spawnProbability;
}
public class BalloonSpawner : MonoBehaviour
{
    public BalloonSpawnInfo[] balloonsToSpawn;
    public float spawnIntervalInSeconds = 1.0f;
    public int maxNumberOfObjectsToSpawn = 40;
    public GameManager gameManager;

    private List<GameObject> spawnedBalloons = new List<GameObject>();
    private float lastSpawnTime;

    void Start()
    {
        lastSpawnTime = Time.time;
        InvokeRepeating("SpawnBalloon", spawnIntervalInSeconds, spawnIntervalInSeconds);
    }

    public void SpawnBalloon()
    {
        if (spawnedBalloons.Count >= maxNumberOfObjectsToSpawn)
        {
            DestroyOldestObject();
        }

        float randomValue = Random.value;
        float totalProbability = 0f;

        foreach (var balloonInfo in balloonsToSpawn)
        {
            totalProbability += balloonInfo.spawnProbability;
            if(Random.value <= totalProbability)
            {
                GameObject newBalloon = Instantiate(balloonInfo.balloonPrefab, GetRandomPosition(), Quaternion.identity);
                BalloonHit balloonHit = newBalloon.GetComponentInChildren<BalloonHit>();
                if (balloonHit != null)
                {
                    balloonHit.SetGameManagerReference(gameManager);
                }
                else
                {
                    Debug.LogWarning("can't set game manger reference on colliders in balloons");
                }

                spawnedBalloons.Add(newBalloon);
                break;
            }
        }
    }

    private void DestroyOldestObject()
    {
        if (spawnedBalloons.Count > 0)
        {
            GameObject oldestObject = spawnedBalloons[0];
            spawnedBalloons.RemoveAt(0);
            Destroy(oldestObject);
        }
    }
    
    private Vector3 GetRandomPosition()
    {
        // Return a random position within the boundary
        return new Vector3(
            Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2),
            Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2),
            Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)
        );
    }
}
