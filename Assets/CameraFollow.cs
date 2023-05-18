using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        this.FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 localOffset = target.transform.up * 5f - target.transform.forward * 6f;
        transform.position = target.transform.position + localOffset;
        Quaternion rot = Quaternion.LookRotation(target.transform.position - transform.position + new Vector3(0, 2 ,0), target.transform.up);
        transform.rotation = rot;
    }
}
