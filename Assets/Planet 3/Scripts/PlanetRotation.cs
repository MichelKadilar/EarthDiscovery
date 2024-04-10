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
    private Vector3 targetCapitalPosition = Vector3.zero; // Position de la capitale cible
    private bool shouldRotateToCapital = false; // Si on doit effectuer une rotation automatique vers la capitale


    void Update()
    {
        if (shouldRotateToCapital)
        {
            // Calculez ici la rotation nécessaire pour "regarder" vers la capitale
            Quaternion targetRotation = Quaternion.LookRotation(targetCapitalPosition - transform.position, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSensitivity);
            // Condition pour arrêter la rotation automatique, par exemple, lorsque la rotation est suffisamment proche de la cible
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
            {
                shouldRotateToCapital = false; // Stoppe la rotation automatique
            }
        }
        else
        {
            // Votre logique existante de rotation manuelle et d'inertie
            HandleManualRotation();
        }
    
        // Mise à jour de la dernière position de la souris (déplacé de la logique manuelle)
        lastMousePosition = Input.mousePosition;
    }

    public void RotateTowardsCapital(Vector3 capitalPosition)
    {
        targetCapitalPosition = capitalPosition - transform.position;
        shouldRotateToCapital = true;
    }

    void RotatePlanet(Vector3 rotationSpeed)
    {
        // Rotation de la planète en utilisant la vitesse de rotation calculée
        transform.Rotate(rotationSpeed, Space.World);
    }

    void HandleManualRotation()
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
        ;
    }
    
}
