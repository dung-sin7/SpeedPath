using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarControlller : MonoBehaviour
{
    [SerializeField] List<WheelCollider> wheelColliders;

    [SerializeField] List<Transform> wheels;

    [SerializeField] float torque = 200f;

    [SerializeField] float angle = 45f;

    private void FixedUpdate()
    {
        for (int i = 0; i < wheelColliders.Count; i++)
        {
            wheelColliders[i].motorTorque = Input.GetAxis("Vertical") * torque;
            if (i == 0 || i == 3)
            {
                wheelColliders[i].steerAngle = Input.GetAxis("Horizontal") * angle;

            }
        }
    }


}
