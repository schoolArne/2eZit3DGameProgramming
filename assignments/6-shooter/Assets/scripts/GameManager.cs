using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timerDurationInMilliseconds = 90000;

    private float timer = 0f;
    private bool isTimerRunning = false;
    private int totalPoints = 0;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        StartTimer();
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Ensures there's only one instance
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // Keep this GameObject across scenes
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timer -= Time.deltaTime * 1000;

            if (timer <= 0)
            {
                isTimerRunning = false;
                SceneManager.LoadScene("EndScreen");
            }
        }
    }

    public void addPointsToTotalPoints(int amount)
    {
        totalPoints += amount;
    }
    public int getTotalPoints()
    {
        return totalPoints;
    }

    private void StartTimer()
    {
        timer = timerDurationInMilliseconds;
        isTimerRunning = true;
    }

    public float GetRemainingTime()
    {
        return timer;
    }
}
