using UnityEngine;

public class PlanetZoom : MonoBehaviour
{
    public Transform target; // Cible du zoom, ici votre planète
    public float zoomSpeed = 10f; // Vitesse de zoom
    public float minZoomDistance = 5f; // Distance minimale de zoom
    public float maxZoomDistance = 50f; // Distance maximale de zoom

    private Vector3 initialOffset; // Position initiale de la caméra par rapport à la cible
    private float currentZoomDistance; // Distance actuelle de zoom

    void Start()
    {
        // Calcul de l'offset initial basé sur les positions initiales de la caméra et de la cible
        initialOffset = transform.position - target.position;
        // Calcul de la distance de zoom initiale
        currentZoomDistance = initialOffset.magnitude;
    }

    void Update()
    {
        // Lecture de l'input de zoom (molette de la souris ou touchpad)
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        // Calcul de la nouvelle distance de zoom souhaitée
        currentZoomDistance -= zoomInput * zoomSpeed;
        // Clamp de la distance de zoom entre les valeurs min et max
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);
        
        // Mise à jour de la position de la caméra basée sur la nouvelle distance de zoom
        // La caméra reste toujours orientée vers la cible grâce à l'offset calculé
        transform.position = target.position + initialOffset.normalized * currentZoomDistance;
        
        // Optionnel : S'assurer que la caméra regarde toujours vers la cible
        transform.LookAt(target);
    }
}