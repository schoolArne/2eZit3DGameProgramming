using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public void LoadNextScene()
    {
        Debug.Log("Button clicked!");
        SceneManager.LoadScene("level1");
    }
}
