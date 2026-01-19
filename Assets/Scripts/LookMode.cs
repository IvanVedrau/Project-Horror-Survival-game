// LookMode.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookMode : MonoBehaviour
{
    private PostProcessVolume vol;
    public PostProcessProfile standard;
    public PostProcessProfile nightVision;
    public PostProcessProfile inventory;
    public GameObject nightVisionOverlay;
    public GameObject flashlightOverlay;
    public GameObject inventoryMenu;
    private bool nightVisionOn = false;
    private bool flashlightOn = false;
    private Light flashLight;

    

    // Start is called before the first frame update
    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        flashLight = GameObject.Find("FlashLight").GetComponent<Light>();
        nightVisionOverlay.SetActive(false);
        flashLight.enabled = false;
        flashlightOverlay.SetActive(false);
        inventoryMenu.SetActive(false);
        vol.profile = standard;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.inventoryOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (nightVisionOn == false)
                {
                    vol.profile = nightVision;
                    nightVisionOverlay.SetActive(true);
                    nightVisionOn = true;
                    NightVisionOff();
                }
                else if (nightVisionOn == true)
                {
                    vol.profile = standard;
                    nightVisionOverlay.SetActive(false);
                    nightVisionOverlay.GetComponent<NightVisionScript>().StopDrain();
                    this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                    nightVisionOn = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (SaveScript.inventoryOpen == false)
            {

                if (flashlightOn == false)
                {
                    flashlightOverlay.SetActive(true);
                    flashlightOn = true;
                    flashLight.enabled = true;
                    FlashLightSwitchOff();
                }
                else if (flashlightOn == true)
                {
                    flashlightOverlay.SetActive(false);
                    flashlightOverlay.GetComponent<FlashLightScript>().StopDrain();
                    flashlightOn = false;
                    flashLight.enabled = false;
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            
                if (SaveScript.inventoryOpen == false) 
            {
                vol.profile = inventory;
                inventoryMenu.SetActive(true);


                if (flashlightOn == true)
                {
                    flashlightOverlay.SetActive(false);
                    flashLight.enabled = false;
                    flashlightOverlay.GetComponent<FlashLightScript>().StopDrain();
                    flashlightOn = false;
                    
                }

                if (nightVisionOn == true)
                {
                    nightVisionOverlay.SetActive(false);
                    nightVisionOverlay.GetComponent<NightVisionScript>().StopDrain();
                    this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                    nightVisionOn = false;
                }
            }
            else if (SaveScript.inventoryOpen == true)
            {
                vol.profile = standard;
                inventoryMenu.SetActive(false);
            }
        }

        if (nightVisionOn == true)
        {
            NightVisionOff();
        }

        if (flashlightOn == true)
        {
            FlashLightSwitchOff();
        }

    }

    private void NightVisionOff()
    {
        if (nightVisionOverlay.GetComponent<NightVisionScript>().batteryChunks <= 0)
        {
            vol.profile = standard;
            nightVisionOverlay.SetActive(false);
            this.gameObject.GetComponent<Camera>().fieldOfView = 60;
            nightVisionOn = false;
        }
    }

    private void FlashLightSwitchOff()
    {
        if (flashlightOverlay.GetComponent<FlashLightScript>().batteryChunks <= 0)
        {
            flashlightOverlay.SetActive(false);
            flashLight.enabled = false;
            this.gameObject.GetComponent<Camera>().fieldOfView = 60;
            flashlightOn = false;
        }
    }
}
