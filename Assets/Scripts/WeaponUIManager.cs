using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    public GameObject pistolPanel, shotgunPanel, spraycanPanel;
    public Text pistolTotalAmmo, pistolCurrentAmmo, shotgunTotalAmmo, shotgunCurrentAmmo;
    private bool panelOn = false;

    void Start()
    {
        SetPanel(pistolPanel, false);
        SetPanel(shotgunPanel, false);
        SetPanel(spraycanPanel, false);
    }

    void Update()
    {
        if (SaveScript.weaponID == 4)
        {
            if (panelOn == false)
            {
                panelOn = true;
                SetPanel(pistolPanel, true);
            }
        }

        if (SaveScript.weaponID == 5)
        {
            if (panelOn == false)
            {
                panelOn = true;
                SetPanel(shotgunPanel, true);
            }
        }

        if (SaveScript.weaponID == 6)
        {
            if (panelOn == false)
            {
                panelOn = true;
                SetPanel(spraycanPanel, true);
            }
        }

        if (SaveScript.inventoryOpen == true)
        {
            SetPanel(pistolPanel, false);
            SetPanel(shotgunPanel, false);
            SetPanel(spraycanPanel, false);
            panelOn = false;
        }

        RefreshAmmoText();
    }

   
    private void RefreshAmmoText()
    {
        SetText(pistolTotalAmmo, SaveScript.ammoAmts[0]);
        SetText(shotgunTotalAmmo, SaveScript.ammoAmts[1]);
        SetText(pistolCurrentAmmo, SaveScript.currentAmmo[4]);
        SetText(shotgunCurrentAmmo, SaveScript.currentAmmo[5]);
    }

    
    private void SetText(Text field, int value)
    {
        if (field == null) return;
        field.text = value.ToString();
    }

    private void SetPanel(GameObject panel, bool state)
    {
        if (panel == null) return;
        panel.SetActive(state);
    }
}
