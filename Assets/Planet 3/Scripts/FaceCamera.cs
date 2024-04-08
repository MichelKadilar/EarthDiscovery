using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        Transform newCamera = Camera.main.transform;
        // Fait face à la caméra
        Vector3 directionToCamera = transform.position - newCamera.transform.position;
        
        // Annule la rotation sur l'axe y pour éviter l'inclinaison du texte
        directionToCamera.y = 0;

        // Applique la rotation
        transform.rotation = Quaternion.LookRotation(directionToCamera);
    }
}

