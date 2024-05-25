using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoInteractable : MonoBehaviour
{
    private bool CurrentlyShowingMessage = false;
    public TMP_Text textElement;
    [TextArea(3, 20)]
    public string message = "";
    public void OnInteract()
    {
        textElement.text = message;
        Debug.Log(textElement.text);
        CurrentlyShowingMessage = true;
    }
    public void Update()
    {
        if(CurrentlyShowingMessage)
        {
            if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
            {
                textElement.text = "";
                CurrentlyShowingMessage = false;
            }
        }
    }
}
