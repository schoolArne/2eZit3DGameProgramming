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
            Vector3 newPosition = transform.position + new Vector3(0, 0.5f, 0);
            Instantiate(CorrelatingDeadTrashObject, newPosition, transform.rotation);
        }
        Destroy(gameObject);
    }
}
