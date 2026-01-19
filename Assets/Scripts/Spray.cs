using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spray : MonoBehaviour
{
    public Image sprayFill;
    public float sprayAmount = 1.0f;
    public float drainTime = 2.0f; // Time to drain the spray can completely

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            sprayAmount -= drainTime * Time.deltaTime;
            sprayFill.fillAmount = sprayAmount;
        }
    }
}
