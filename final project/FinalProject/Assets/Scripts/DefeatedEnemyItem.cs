using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatedEnemyItem : MonoBehaviour
{
    public string correctInventoryReference = "";
    private float rotationSpeed = 100f;
    private float bobbingAmplitude = 0.5f;
    private float bobbingSpeed = 2f;
    private float initialY;
    private GameManager gameManager;
    void Start()
    {
        initialY = transform.position.y;
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }
    void Update()
    {
        Spin();
        Bob();
    }
    void Spin()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    void Bob()
    {
        float newY = initialY + Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null || correctInventoryReference != "")
            {
                gameManager.UpdateTrashInventory(correctInventoryReference, 1);
            }
            Destroy(gameObject);
        }
    }
}
