using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class TimerTextUpdater : MonoBehaviour
{
    public GameManager manager;
    public TMP_Text timerTextBox;

    void Update()
    {
        float remainingTime = manager.GetRemainingTime();
        timerTextBox.text = formatTimeNotation(remainingTime);
        Color textColor;
        if(remainingTime > 10000f)
        {
            textColor = Color.white;
        }
        else
        {
            if(remainingTime <= 0f)
            {
                textColor = Color.white;
            }
            else
            {
                textColor = Color.red;
            }
        }
        timerTextBox.color = textColor;
    }

    private string formatTimeNotation(float timeInMilliseconds)
    {
        if (timeInMilliseconds > 0)
        {
            // Convert the timeInMilliseconds to a TimeSpan
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(timeInMilliseconds);

            // Format the TimeSpan as "mm\:ss\.fff" (minutes:seconds.milliseconds)
            string formattedTime = timeSpan.ToString(@"mm\:ss\.fff");

            return formattedTime;
        }
        else
        {
            return "FINISHED";
        }
    }
}
