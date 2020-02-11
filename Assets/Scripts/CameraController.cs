using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public float smoothSpeed = 3f;
    public Vector3 offsets;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offsets;
        desiredPosition.y = 0;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
