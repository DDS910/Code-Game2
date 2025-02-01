using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, moveSpeed);
        transform.position = smoothPos;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
