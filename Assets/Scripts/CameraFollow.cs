using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float height;
    [SerializeField] private float smoothness;

    [SerializeField] private Transform target;

    private Vector3 velocity;

    private void LateUpdate()
    {
        Vector3 pos = Vector3.zero;
        pos.x = target.position.x;
        pos.y = target.position.y + height;
        pos.z = target.position.z - distance;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness);
    }


}
