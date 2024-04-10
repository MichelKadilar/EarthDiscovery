using UnityEngine;

public class FairyFollower : MonoBehaviour
{
    public Transform player; // Référence au Transform du joueur
    public Vector3 offset; // Décalage de position par rapport au joueur
    public float smoothTime = 0.3f; // Temps pour atteindre la position cible
    public float rotationSpeed = 5.0f; // Vitesse de rotation de la fée pour qu'elle regarde vers le joueur

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Calcule la position cible de la fée basée sur la position du joueur et le décalage
        Vector3 targetPosition = player.position + offset;

        // Utilise SmoothDamp pour déplacer la fée vers la position cible de manière fluide
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Calculer la direction vers laquelle la fée devrait regarder, en se basant sur la position "devant" le joueur
        Vector3 frontOfPlayer = player.position + player.forward * 2; // Ajustez ce multiplicateur selon la distance devant le joueur
        Vector3 directionToLookAt = frontOfPlayer - transform.position;

        // Rotation pour que la fée regarde toujours le joueur, mais seulement en ajustant l'axe Y
        if (directionToLookAt != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToLookAt);
            // Créer une nouvelle rotation qui conserve les rotations actuelles en X et Z, mais utilise la rotation cible en Y
            Quaternion limitedRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, limitedRotation, rotationSpeed * Time.deltaTime);
        }
    }
}