using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (gameManager != null)
            {
                gameManager.TrashWentIntoWrongTrashBin();
            }
        }
    }
}