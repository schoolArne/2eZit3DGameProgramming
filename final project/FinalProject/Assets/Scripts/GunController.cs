using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Camera playerCamera;
    public float shootingRange = 100f;
    public GameObject impactEffect;
    public GameObject muzzleFlash;
    public GameManager gameManager;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (muzzleFlash != null)
        {
            muzzleFlash.SetActive(false);
        }
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
                if(hit.transform.tag == "enemy")
                {
                    Debug.Log(hit.transform.name);
                    if (impactEffect != null)
                    {
                        Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    }
                }                
            }
            ShowMuzzleFlash();
            gameManager.ShootAndDecreaseAmmoCount();
        }
    }
    void ShowMuzzleFlash()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.SetActive(true);
            StartCoroutine(HideMuzzleFlash());
        }
    }

    IEnumerator HideMuzzleFlash()
    {
        yield return new WaitForSeconds(0.1f); // Adjust duration as needed
        muzzleFlash.SetActive(false);
    }
}
