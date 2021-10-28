using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public float sensitivity;
    public float distance = 1;
    public float distanceMaxClamp;
    public float distanceMinClamp;
    public float xMaxRotClamp;
    public float xMinRotClamp;
    public float xMaxPosClamp;
    public float xMinPosClamp;
    public GameObject center;
    public Vector3 orbitPoint;

    Vector3 StartPoint = Vector3.zero;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector2 mouseMovement;
            mouseMovement.y = Input.GetAxis("Mouse X");
            mouseMovement.x = Input.GetAxis("Mouse Y");

            center.transform.eulerAngles = new Vector3(center.transform.eulerAngles.x - mouseMovement.x * sensitivity, center.transform.eulerAngles.y + mouseMovement.y * sensitivity, 0);
            if (center.transform.eulerAngles.x >= 300)
            {
                center.transform.eulerAngles = new Vector3(Mathf.Clamp((center.transform.eulerAngles.x - 360) - mouseMovement.x, xMinRotClamp, xMaxRotClamp), center.transform.eulerAngles.y + mouseMovement.y * sensitivity, 0);
            }
            else
            {
                center.transform.eulerAngles = new Vector3(Mathf.Clamp(center.transform.eulerAngles.x - mouseMovement.x, xMinRotClamp, xMaxRotClamp), center.transform.eulerAngles.y + mouseMovement.y * sensitivity, 0);
            }
        }

        Vector3 CurrentPoint;

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                StartPoint = hit.point;
                Debug.Log("Hit");
            }
            Debug.Log("BRuh");
        }
        
        if (Input.GetKey(KeyCode.Mouse2))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                CurrentPoint = hit.point;
                orbitPoint.x += StartPoint.x - CurrentPoint.x;
            }
        }

        
        distance = Mathf.Clamp(distance -= Input.GetAxis("Mouse ScrollWheel"), distanceMinClamp, distanceMaxClamp);

        transform.position = (center.transform.forward * -distance) + orbitPoint;
        transform.rotation = center.transform.rotation;
    }
}
