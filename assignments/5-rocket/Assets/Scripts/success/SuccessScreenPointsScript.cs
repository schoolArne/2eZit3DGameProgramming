using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuccessScreenPointsScript : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    void Start()
    {
        string scoretext = "TOTAL POINTS: " + GameManager.totalScore.ToString();
        pointsText.text = scoretext;
    }
}
