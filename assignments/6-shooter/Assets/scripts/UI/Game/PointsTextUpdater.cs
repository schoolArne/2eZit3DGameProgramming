using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsTextUpdater : MonoBehaviour
{
    public TMP_Text textElement;
    public GameManager gameManager;

    void Update()
    {
        textElement.text = "POINTS: " + gameManager.getTotalPoints().ToString();
    }
}
