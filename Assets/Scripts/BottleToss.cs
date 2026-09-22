using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleToss : MonoBehaviour
{
    public float rotSpeed = 0.5f;
    public float throwPower = 40;
    public GameObject obj;
    public Transform tossDest;

    LineRenderer lineRenderer;

    //line renderer variables
    public int lineRendererPoints = 80;
    public float lineRendererTimeStep = 0.1f;
    public LayerMask collisionLayer;
    public Material lineRendererBlue, lineRendererRed;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
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

        //draw the line renderer
        lineRenderer.positionCount = lineRendererPoints;
        List<Vector3> linePoints = new List<Vector3>();
        Vector3 startPos = tossDest.position;
        Vector3 startVelocity = throwPower * tossDest.forward;

        if (Input.GetMouseButton(1))
        {
            for (float i = 0; i < lineRendererPoints; i+= lineRendererTimeStep)
            {
                Vector3 newpoint = startPos + i * startVelocity;

                //Curve formula
                newpoint.y = startPos.y + startVelocity.y + i + Physics.gravity.y / 2f * i * i;

                linePoints.Add(newpoint);

                //Check for collision and stop drawing
                if (Physics.OverlapSphere(newpoint, 0.01f, collisionLayer).Length > 0)
                {
                    lineRenderer.positionCount = linePoints.Count;
                    break;
                }
            }

            lineRenderer.SetPositions(linePoints.ToArray());
        }

        if (Input.GetMouseButtonUp(1))
            lineRenderer.positionCount = 0;
        

        if (Input.GetMouseButtonDown(0))
        {
            if (SaveScript.weaponID == 7) {
                GameObject instantiateBottle = Instantiate(obj, tossDest.position, tossDest.rotation);

                //throwing of a bottle 
                instantiateBottle.GetComponentInChildren<Rigidbody>().linearVelocity = tossDest.transform.forward * throwPower;
            }
                
        }
    } 
}
