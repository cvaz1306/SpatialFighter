using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform moveTarget; // Target for camera to follow
    public Transform lookTarget; // Target for camera to look at
    public float followSpeed = 5f; // Speed of camera following

    private Vector3 offset; // Offset between camera and move target

    void Start()
    {
        // Calculate initial offset
        offset = transform.position - moveTarget.position;
    }

    void FixedUpdate()
    {
        // Calculate desired position based on move target's position and offset
        Vector3 desiredPosition = moveTarget.position + offset;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Ensure camera is always looking at the look target
        transform.LookAt(lookTarget, lookTarget.up);
    }
}
