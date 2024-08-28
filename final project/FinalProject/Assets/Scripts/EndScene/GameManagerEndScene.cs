using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerEndScene : MonoBehaviour
{
    private TMP_Text scoreText;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        int trashInWrongTrashBin = PlayerPrefs.GetInt("trashinwrongtrashbin", 0);
        int restpickedup = PlayerPrefs.GetInt("restpickedup", 0);
        int pmdpickedup = PlayerPrefs.GetInt("pmdpickedup", 0);
        int paperpickedup = PlayerPrefs.GetInt("paperpickedup", 0);

        GameObject scoreTextObject = GameObject.Find("Score");
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TMP_Text>();
            scoreText.text = "Trash that went into wrong trashbin: " + trashInWrongTrashBin + "\n\n" + "rest picked up: " + restpickedup + "\n" + "pmd picked up: " + pmdpickedup + "\n" + "paper picked up: " + paperpickedup;
        }
    }
    public void OnRestartButtonClicked()
    {
        Debug.Log("log");
        PlayerPrefs.SetInt("trashinwrongtrashbin", 0);
        PlayerPrefs.SetInt("restpickedup", 0);
        PlayerPrefs.SetInt("pmdpickedup", 0);
        PlayerPrefs.SetInt("paperpickedup", 0);
        SceneManager.LoadScene("StartScene");
    }
}
