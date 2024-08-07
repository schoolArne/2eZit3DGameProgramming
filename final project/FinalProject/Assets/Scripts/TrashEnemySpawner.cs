using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashEnemySpawner : MonoBehaviour
{
    public GameObject Trash1;
    public GameObject Trash2;
    public GameObject Trash3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {

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
