using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFollow : MonoBehaviour
{
    [SerializeField]
    Transform rollingBallTransform;

    private void FixedUpdate()
    {
        transform.position = new Vector3(rollingBallTransform.position.x, rollingBallTransform.position.y, rollingBallTransform.position.z);
    }


}
