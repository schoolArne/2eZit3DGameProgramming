using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGoingToWrongTrashBin : MonoBehaviour
{
    private GameObject REST;
    private GameObject Paper;
    private GameObject PMD;
    public TrashType trashType;

    private GameObject target;
    private Rigidbody rb;
    void Start()
    {
        REST = GameObject.Find("Rest");
        Paper = GameObject.Find("Papier");
        PMD = GameObject.Find("PMD");
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        if ( REST != null && Paper != null && PMD != null)
        {
            switch (trashType)
            {
                case TrashType.REST:
                    target = ChooseRandomGameObjectOutOf2(Paper, PMD);
                    break;
                case TrashType.PAPER:
                    target = ChooseRandomGameObjectOutOf2(REST, PMD);
                    break;
                case TrashType.PMD:
                    target = ChooseRandomGameObjectOutOf2(REST, Paper);
                    break;
                default:
                    target = REST;
                    break;
            }
        }        
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
    }
    private void MoveTowardsTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        rb.AddForce(direction * 12f);
    }
    private GameObject ChooseRandomGameObjectOutOf2(GameObject obj1, GameObject obj2)
    {
        int randomIndex = Random.Range(0, 2);
        if (randomIndex == 0)
        {
            return obj1;
        }
        else
        {
            return obj2;
        }
    }
}
public enum TrashType
{
    REST,
    PAPER,
    PMD
}