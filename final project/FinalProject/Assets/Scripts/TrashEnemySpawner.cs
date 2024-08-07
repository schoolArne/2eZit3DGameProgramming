using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashEnemySpawner : MonoBehaviour
{
    public GameObject Trash1;
    public GameObject Trash2;
    public GameObject Trash3;
    public float minimumSpawnTime = 3f;
    public float maximumSpawnTime = 10f;
    void Start()
    {
        StartCoroutine(SpawnEnemyAtRandomIntervals());
    }
    void Update()
    {
        
    }
    IEnumerator SpawnEnemyAtRandomIntervals()
    {
        while (true)
        {
            float waitTime = Random.Range(minimumSpawnTime, maximumSpawnTime);
            yield return new WaitForSeconds(waitTime);
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        GameObject enemyToSpawn = ChooseRandomEnemy();
        if (enemyToSpawn != null)
        {
            Instantiate(enemyToSpawn, transform.position, transform.rotation);
        }
    }
    GameObject ChooseRandomEnemy()
    {
        List<GameObject> enemies = new List<GameObject> { Trash1, Trash2, Trash3 };
        enemies.RemoveAll(enemy => enemy == null);
        if (enemies.Count == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, enemies.Count);
        return enemies[randomIndex];
    }
}
