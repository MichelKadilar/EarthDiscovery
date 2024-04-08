using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationSensitivity = 0.2f; // Sensibilité de la rotation, ajustez selon besoin
    public float inertiaDuration = 1.0f; // Durée de l'inertie en secondes

    private Vector3 rotationVelocity; // Vitesse de rotation actuelle
    private Vector3 lastMousePosition; // Dernière position de la souris
    private float timeSinceLastInput; // Temps écoulé depuis le dernier input de l'utilisateur

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Calcul de la différence de position de la souris depuis la dernière frame
            Vector3 delta = Input.mousePosition - lastMousePosition;
            // Application de la rotation en fonction du mouvement de la souris
            rotationVelocity = new Vector3(delta.y, -delta.x, 0) * rotationSensitivity;
            // Rotation de la planète
            RotatePlanet(rotationVelocity);
            QuestManager questManager = FindObjectOfType<QuestManager>();
            if(questManager.currentQuestIndex == 2)
            {
                questManager.CompleteCurrentQuest();
            }
            // Réinitialisation du compteur depuis le dernier input
            timeSinceLastInput = 0;
        }
        else
        {
            // Application de l'inertie si l'utilisateur ne donne plus d'input
            if (timeSinceLastInput < inertiaDuration)
            {
                // Diminution progressive de la vitesse de rotation
                RotatePlanet(Vector3.Lerp(rotationVelocity, Vector3.zero, timeSinceLastInput / inertiaDuration));
                timeSinceLastInput += Time.deltaTime;
            }
        }
        
        // Mise à jour de la dernière position de la souris
        lastMousePosition = Input.mousePosition;
    }

    void RotatePlanet(Vector3 rotationSpeed)
    {
        // Rotation de la planète en utilisant la vitesse de rotation calculée
        transform.Rotate(rotationSpeed, Space.World);
    }
}
