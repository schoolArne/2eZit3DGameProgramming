using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDyingScript : MonoBehaviour
{
    public GameObject ExplosionGameObject;
    public GameObject CorrelatingDeadTrashObject;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Die()
    {
        if(ExplosionGameObject != null)
        {
            Instantiate(ExplosionGameObject, transform.position, transform.rotation);
        }
        if(CorrelatingDeadTrashObject != null)
        {
            Instantiate(CorrelatingDeadTrashObject, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
