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
    private TMP_Text inventoryText;
    private TMP_Text wrongTrashText;
    private TMP_Text remainingTimeText;
    private Dictionary<string, int> trashInventory = new Dictionary<string, int>();
    private int trashInWrongTrashBin = 0;
    private int remainingTime = 20;
    void Start()
    {
        currentAmmo = startAmmo;
        GameObject ammoTextObject = GameObject.Find("AmmoCount");
        GameObject inventoryTextObject = GameObject.Find("TrashInventoryInfo");
        GameObject trashInWrongTrashBinObject = GameObject.Find("WrongTrashInfo");
        GameObject remainingTimeObject = GameObject.Find("RemainingTime");
        if (ammoTextObject != null)
        {
            ammoText = ammoTextObject.GetComponent<TMP_Text>();
        }
        if (ammoTextObject != null)
        {
            inventoryText = inventoryTextObject.GetComponent<TMP_Text>();
        }
        if(trashInWrongTrashBinObject != null)
        {
            wrongTrashText = trashInWrongTrashBinObject.GetComponent<TMP_Text>();
        }
        if(remainingTimeObject != null)
        {
            remainingTimeText = remainingTimeObject.GetComponent<TMP_Text>();
        }
        trashInventory["PAPER"] = 0;
        trashInventory["REST"] = 0;
        trashInventory["PMD"] = 0;
    }
    void Update()
    {
        remainingTime--;
        UpdateAmmoText(currentAmmo);
        UpdateInventoryText();
        UpdateWrongTrashText();
        UpdateRemainingTime();
        if(remainingTime == 0)
        {
            EndGame();
        }
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
    public void UpdateTrashInventory(string name, int amount)
    {
        if (name == "PAPER" || name == "REST" || name == "PMD")
        {
            trashInventory[name] += amount;
        }
    }
    public int GetCurrentAmountOFTrashInInventory(string name)
    {
        if (name == "PAPER" || name == "REST" || name == "PMD")
        {
            return trashInventory[name];
        }
        return 0;
    }
    private void UpdateInventoryText()
    {
        if (inventoryText != null)
        {
            inventoryText.text = "REST: " + trashInventory["REST"] + "\n" + "PAPER: " + trashInventory["PAPER"] + "\n" + "PMD: " + trashInventory["PMD"];
        }
    }
    public void TrashWentIntoWrongTrashBin()
    {
        trashInWrongTrashBin++;
    }
    private void UpdateWrongTrashText()
    {
        if(wrongTrashText != null)
        {
            wrongTrashText.text = "Trash In Wrong Trashbin: " + trashInWrongTrashBin;
        }
    }
    private void UpdateRemainingTime()
    {
        if(remainingTimeText != null)
        {
            remainingTimeText.text = "REMAINING TIME: " + remainingTime;
        }
    }
    private void EndGame()
    {
        Debug.Log("end");
    }
}
