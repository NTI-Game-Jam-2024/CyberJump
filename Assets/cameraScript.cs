using UnityEngine;

public class cameraScript: MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector3 offset; // Offset from the player's position


    void LateUpdate()
    {
        if (target != null)
        {
            // Keep the camera's rotation fixed
            transform.rotation = Quaternion.Euler(0, 0, 0);

            // Update the camera's position to follow the player
            transform.position = target.position + offset;
        }
    }
}



