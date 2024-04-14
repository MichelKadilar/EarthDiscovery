using Unity.VisualScripting;
using UnityEngine;

public class CarMovementBot : MonoBehaviour
{
    // Vitesse de déplacement
    public float forwardMoveSpeed = 5000f;
    public float backwardMoveSpeed = 2500f;
    public float brakeForce = 3000f;
    private Vector2 inputPlayer;
    // Vitesse et angle de direction
    public float steerSpeed = 30f;

    // Références aux colliders et meshes des roues
    public WheelCollider frontLeftCollider;
    public WheelCollider frontRightCollider;
    public WheelCollider rearLeftCollider;
    public WheelCollider rearRightCollider;

    // Références aux gameObjects des roues pour la rotation visuelle (non nécessaire pour le mouvement physique)
    public GameObject frontLeftMesh;
    public GameObject frontRightMesh;
    public GameObject rearLeftMesh;
    public GameObject rearRightMesh;

    public void SetInputs(Vector2 input)
    {
        inputPlayer = input;
    }

    void FixedUpdate()
    {
        float speed = inputPlayer.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        float currentSpeed = rearLeftCollider.rpm * (2 * Mathf.PI * rearLeftCollider.radius) * 60 / 1000;  // Calculer la vitesse actuelle en km/h
        float brake = (currentSpeed > 0 && inputPlayer.y < 0) ? brakeForce : 0f;
        
        rearLeftCollider.motorTorque = inputPlayer.y * speed;
        rearRightCollider.motorTorque = inputPlayer.y * speed;

        // Appliquer le freinage à tous les WheelColliders
        frontLeftCollider.brakeTorque = brake;
        frontRightCollider.brakeTorque = brake;
        rearLeftCollider.brakeTorque = brake;
        rearRightCollider.brakeTorque = brake;
    

        // Appliquer la direction aux roues avant
        float steerAngle = inputPlayer.x * steerSpeed;
        frontLeftCollider.steerAngle = steerAngle;
        frontRightCollider.steerAngle = steerAngle;

        UpdateWheelPositions();
    }

    // Mettre à jour la position et la rotation des meshes des roues pour qu'elles correspondent aux WheelColliders
    void UpdateWheelPositions()
    {
        UpdateWheelPosition(frontLeftCollider, frontLeftMesh);
        UpdateWheelPosition(frontRightCollider, frontRightMesh);
        UpdateWheelPosition(rearLeftCollider, rearLeftMesh);
        UpdateWheelPosition(rearRightCollider, rearRightMesh);
    }
    
    public float CurrentSpeed
    {
        get { return rearLeftCollider.rpm * (2 * Mathf.PI * rearLeftCollider.radius) * 60 / 1000; } // Convertit rpm en km/h
    }

    void UpdateWheelPosition(WheelCollider collider, GameObject mesh)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        mesh.transform.position = position;
        mesh.transform.rotation = rotation;
    }
}
