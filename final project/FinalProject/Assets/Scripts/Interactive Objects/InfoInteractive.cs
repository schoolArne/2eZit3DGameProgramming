using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoInteractable : MonoBehaviour
{
    private bool currentlyShowingMessage = false;
    public GameObject textElement;

    private void Start()
    {
        if (textElement != null)
        {
            textElement.SetActive(false);
        }
    }

    public void OnInteract()
    {
        if (textElement != null)
        {
            currentlyShowingMessage = true;
            textElement.SetActive(true);
        }
    }

    private void Update()
    {
        if (currentlyShowingMessage)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (textElement != null)
                {
                    textElement.SetActive(false);
                }
                currentlyShowingMessage = false;
            }
        }
    }
}
