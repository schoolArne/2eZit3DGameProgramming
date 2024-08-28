using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEndScene : MonoBehaviour
{
    void Start()
    {
        int trashInWrongTrashBin = PlayerPrefs.GetInt("trashinwrongtrashbin", 0);
        int restpickedup = PlayerPrefs.GetInt("restpickedup", 0);
        int pmdpickedup = PlayerPrefs.GetInt("pmdpickedup", 0);
        int paperpickedup = PlayerPrefs.GetInt("paperpickedup", 0);
        Debug.Log(trashInWrongTrashBin + " " + restpickedup + " " + pmdpickedup + " " + paperpickedup);
    }
}
