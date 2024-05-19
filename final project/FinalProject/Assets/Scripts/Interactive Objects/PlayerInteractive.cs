using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    public float interactionRange = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    InfoInteractable infoInteractable = hit.collider.GetComponent<InfoInteractable>();
                    if (infoInteractable != null)
                    {
                        infoInteractable.OnInteract();
                    }
                }
            }
        }
    }
}
