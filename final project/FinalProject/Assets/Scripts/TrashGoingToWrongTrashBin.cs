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
    void Start()
    {
        REST = GameObject.Find("Rest");
        Paper = GameObject.Find("Papier");
        PMD = GameObject.Find("PMD");
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
    void Update()
    {
        //move to wrong trash bin in some way
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