using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Camera playerCamera;
    public float shootingRange = 100f;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public GameManager gameManager;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
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
        if(gameManager.GetCurrentAmmo() != 0)
        {
            if(audioSource != null)
            {
                audioSource.Play();
            }
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, shootingRange))
            {
                Debug.Log(hit.transform.name);

                if (impactEffect != null)
                {
                    Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                }

                StartCoroutine(ShowShotEffect(hit.point));
            }
            else
            {
                StartCoroutine(ShowShotEffect(playerCamera.transform.position + playerCamera.transform.forward * shootingRange));
            }
            gameManager.ShootAndDecreaseAmmoCount();
        }
    }

    IEnumerator ShowShotEffect(Vector3 hitPoint)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hitPoint);

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.1f);

        lineRenderer.enabled = false;
    }
}
