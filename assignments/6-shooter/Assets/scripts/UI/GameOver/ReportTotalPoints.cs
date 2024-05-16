using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReportTotalPoints : MonoBehaviour
{
    public TMP_Text textBox;
    
    void Start()
    {
        textBox.text = "TOTAL POINTS GATHERED: " + GameManager.Instance.getTotalPoints().ToString();
    }
}
