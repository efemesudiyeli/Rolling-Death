using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    // Keys
    [SerializeField] KeyCode forwardKey = KeyCode.W;
    [SerializeField] KeyCode backwardKey = KeyCode.S;
    [SerializeField] KeyCode leftKey = KeyCode.A;
    [SerializeField] KeyCode rightKey = KeyCode.D;
    // Rolling Speed
    [SerializeField] float rollingVelocity = 10f;

    [SerializeField] Transform Cam;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        Vector3 camForward = Cam.forward;
        camForward.y = 0f; // Dikey ekseni sıfır yaparak yalnızca yatay düzlemde hareket etmesini sağla
        camForward.Normalize(); // Vektörü normalize et

        Vector3 camRight = Cam.right;
        camRight.y = 0f; // Dikey ekseni sıfır yaparak yalnızca yatay düzlemde hareket etmesini sağla
        camRight.Normalize(); // Vektörü normalize et

        // Forward & Backward
        if (Input.GetKey(forwardKey))
        {
            rb.AddForce(camForward * rollingVelocity, ForceMode.Force);
        }
        if (Input.GetKey(backwardKey))
        {
            rb.AddForce(-camForward * rollingVelocity, ForceMode.Force);
        }

        // Left & Right
        if (Input.GetKey(rightKey))
        {
            rb.AddForce(camRight * rollingVelocity, ForceMode.Force);
        }
        if (Input.GetKey(leftKey))
        {
            rb.AddForce(-camRight * rollingVelocity, ForceMode.Force);
        }
    }
}
