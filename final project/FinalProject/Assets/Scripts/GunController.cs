using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Camera playerCamera;   // Reference to the player's camera
    public float shootingRange = 100f;   // The range of the raycast
    public GameObject impactEffect;   // Prefab for the impact effect
    public LineRenderer lineRenderer;   // LineRenderer for the visible raycast
    public GameManager gameManager;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   // "Fire1" is the default left mouse button
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.ResetAmmoCount();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, shootingRange))
        {
            Debug.Log(hit.transform.name);

            // Show impact effect
            if (impactEffect != null)
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

            // Visualize the raycast
            StartCoroutine(ShowShotEffect(hit.point));
        }
        else
        {
            // Visualize the raycast even if it doesn't hit anything
            StartCoroutine(ShowShotEffect(playerCamera.transform.position + playerCamera.transform.forward * shootingRange));
        }
        gameManager.ShootAndDecreaseAmmoCount();
    }

    IEnumerator ShowShotEffect(Vector3 hitPoint)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hitPoint);

        lineRenderer.enabled = true;

        // Wait for a short time
        yield return new WaitForSeconds(0.1f);

        lineRenderer.enabled = false;
    }
}
