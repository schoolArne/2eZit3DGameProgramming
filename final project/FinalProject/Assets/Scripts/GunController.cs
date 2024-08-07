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
        if (gameManager.GetCurrentAmmo() != 0)
        {
            if (audioSource != null)
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
                StartCoroutine(ShowShotEffect());
            }
            else
            {
                StartCoroutine(ShowShotEffect());
            }
            gameManager.ShootAndDecreaseAmmoCount();
        }
    }

    IEnumerator ShowShotEffect()
    {
        yield return null;
    }
}
