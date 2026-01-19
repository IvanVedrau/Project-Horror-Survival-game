using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightScript : MonoBehaviour
{
    private Image batteryPower;
    public float batteryChunks = 1.0f;
    public float drainTime = 2;

    // Start is called before the first frame update
    void OnEnable()
    {
        batteryPower = GameObject.Find("FLBatteryChunks").GetComponent<Image>();
        InvokeRepeating("FLBatteryDrain", drainTime, drainTime);

    }

    // Update is called once per frame
    void Update()
    {
        batteryPower.fillAmount = batteryChunks;
    }

    private void FLBatteryDrain()
    {
        if (batteryChunks > 0)
            batteryChunks -= 0.25f;
    }

    public void StopDrain()
    {
        CancelInvoke("FLBatteryDrain");
    }
}
