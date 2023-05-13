using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        this.FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 localOffset = target.transform.up * 5f - target.transform.forward * 9f;
        transform.position = target.transform.position + localOffset;
        var euler = target.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(euler.x + 20, euler.y, euler.z);
    }
}
