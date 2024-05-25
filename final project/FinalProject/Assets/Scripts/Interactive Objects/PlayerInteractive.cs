using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    public float interactionRange = 5f;
    public TMP_Text interactionMessage;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                interactionMessage.enabled = true;
                if (Input.GetMouseButtonDown(1))
                {
                    InfoInteractable infoInteractable = hit.collider.GetComponent<InfoInteractable>();
                    if (infoInteractable != null)
                    {
                        Debug.Log("interact");
                        infoInteractable.OnInteract();
                    }
                }
            }
            else
            {
                interactionMessage.enabled = false;
            }
        }
        else
        {
            interactionMessage.enabled = false;
        }
    }
}
