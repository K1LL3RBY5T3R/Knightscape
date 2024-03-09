using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f;

    // LateUpdate is called every frame after all other Update functions have been called
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // Calculate the desired position of the camera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smoothly interpolate between the current camera position and the desired position
            transform.position = smoothedPosition; // Update the camera position
        }
    }
}
