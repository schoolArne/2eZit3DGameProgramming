using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxAmmo = 50;
    public int startAmmo = 50;
    private int currentAmmo = 0;
    private TMP_Text ammoText;
    void Start()
    {
        currentAmmo = startAmmo;
        GameObject ammoTextObject = GameObject.Find("AmmoCount");
        if (ammoTextObject != null)
        {
            ammoText = ammoTextObject.GetComponent<TMP_Text>();
        }        
    }
    void Update()
    {
        UpdateAmmoText(currentAmmo);
    }
    public void ShootAndDecreaseAmmoCount()
    {
        if (currentAmmo != 0)
        {
            currentAmmo--;
        }
    }
    public void ResetAmmoCount()
    {
        currentAmmo = maxAmmo;
    } 
    private void UpdateAmmoText(int currentAmmoAtTheMoment)
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmoAtTheMoment.ToString() + "/" + maxAmmo.ToString();
        }
    }
    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }
}
