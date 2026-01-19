using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleToss : MonoBehaviour
{
    public float rotSpeed = 0.5f;
    public float throwPower = 40;
    public GameObject obj;
    public Transform tossDest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * 2;
        float verticalRotation = Input.GetAxis("Mouse Y") * 2;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, horizontalRotation * rotSpeed, verticalRotation * rotSpeed));

        if (Input.GetAxis("Mouse Y") > 0)
        {
            if (throwPower < 70)
                throwPower += 6 * Time.deltaTime;
        }

        if (Input.GetAxis("Mouse Y") < 0)
        {
            if (throwPower > 20)
                throwPower -= 12 * Time.deltaTime;
        }
    }
}
