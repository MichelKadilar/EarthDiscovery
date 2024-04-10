using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    public float moveDistance = 0.5f; // Distance à déplacer vers la gauche

    // Appeler cette méthode pour déplacer le plane vers la gauche
    public void MoveLeft()
    {
        Debug.Log("Moving plane to the left");
        // Déplace le plane vers la gauche en soustrayant de la position x
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z- moveDistance);
    }
}
