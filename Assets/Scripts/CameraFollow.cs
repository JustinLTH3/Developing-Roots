using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Target the Camera to Follow
    public Transform target;

    public float smoothSpeed = 0.125f;
    //distance between camera and player
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPositon = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPositon;
    }
}

