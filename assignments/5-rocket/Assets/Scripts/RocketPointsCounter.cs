using TMPro;
using UnityEngine;

public class RocketPointsCounter : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI pointsText;

    private void Start()
    {
        UpdatePointsText();
    }

    public void IncreasePoints(int amount)
    {
        points += amount;
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        if(pointsText != null)
        {
            pointsText.text = "points: " + points;
        }
    }

    public void SumPointsToTotalScore()
    {
        GameManager.totalScore += points;
    }
}
