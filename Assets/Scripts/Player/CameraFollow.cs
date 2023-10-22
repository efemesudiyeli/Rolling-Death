using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform target;

    [SerializeField] float mouseSpeed, xrot, yrot, minX, maxX;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        // Camera movement
        xrot -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed;
        yrot += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed;
        xrot = Mathf.Clamp(xrot, minX, maxX);
        transform.GetChild(0).localRotation = Quaternion.Euler(xrot, 0, 0);
        transform.localRotation = Quaternion.Euler(0, yrot, 0);



        // Camera follow the target
        transform.position = Vector3.Lerp(transform.position, target.transform.position, 0.3f);

    }


}
