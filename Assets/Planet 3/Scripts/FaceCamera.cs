using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Transform newCamera = mainCamera.transform;
            Vector3 directionToCamera = transform.position - newCamera.position;
        
            // Reset the Y component of directionToCamera to avoid tilting the text
            directionToCamera.y = 0;

            // Apply the rotation to face the camera
            transform.rotation = Quaternion.LookRotation(directionToCamera);
        }
        else
        {
            Debug.LogWarning("Main camera not found. Check if it's tagged as 'MainCamera' and active.");
        }
    }
}

