using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AIControls : MonoBehaviour
{
    public UnityEvent<Vector2> onInput;
    public CarMovementBot carMovement;
    public Transform waypointsHolder;
    public List<Transform> waypointsOfEndStraight;
    public float distanceToBrake = 50;

    public float maxDistanceToTarget = 5f;
    public float directionAdjustmentThreshold = 0.1f; // Seuil pour ajustement de direction
    public float randomJitterOnPosition = .5f;
    public float speedThreshold = 6f; // Seuil de vitesse pour considérer que le bot est bloqué
    public float stuckTimeThreshold = 3f; // Temps à passer bloqué avant de reculer
    public float reverseTime; // Durée de la marche arrière
    
    private bool isReversing = false;
    private List<Transform> waypoints;
    private Transform nextWaypoint;
    private Vector3 nextWaypointPosition;
    private Vector2 input;
    private Vector3 lastPosition;
    private float timeStuck = 0f;
    
    void Awake()
    {
        waypoints = new List<Transform>();

        foreach (Transform child in waypointsHolder)
        {
            if (child != waypointsHolder.transform) // Exclut le Transform du waypointsHolder lui-même
            {
                waypoints.Add(child);
            }
        }
    }

    void Start()
    {
        // Start with first waypoint
        if (waypoints.Count > 0)
        {
            SelectWaypoint(waypoints[0]);
        }
        lastPosition = transform.position;
    }

    void Update()
    {
        float speed = carMovement.CurrentSpeed;
        lastPosition = transform.position;
        
        // Change to next waypoint if reached current waypoint
        float distanceToTarget = Vector3.Distance(transform.position, nextWaypointPosition);
        
        if (isReversing)
        {
            Debug.Log("Reversing...");
            input.x = 0; // Pas de direction en marche arrière
            input.y = -1; // Marche arrière
        }
        else
        {
            if (distanceToTarget < maxDistanceToTarget)
            {
                int nextIndex = waypoints.IndexOf(nextWaypoint) + 1;
                SelectWaypoint(nextIndex < waypoints.Count ? waypoints[nextIndex] : waypoints[0]);
            }

            // Compute Vector2 input based on distances in Right and Forward axis
            Vector3 diff = nextWaypointPosition - transform.position;
            float componentForward = Vector3.Dot(diff, transform.forward.normalized);
            float componentRight = Vector3.Dot(diff, transform.right.normalized);

            // Appliquer le seuil pour l'ajustement de direction
            if (Mathf.Abs(componentRight) > directionAdjustmentThreshold)
            {
                input.x = Mathf.Sign(componentRight);
            }
            else
            {
                input.x = 0;
            }
            if (distanceToTarget < distanceToBrake && waypointsOfEndStraight.Contains(nextWaypoint) && speed > 100)
            {
                input.y = -1;
            }
            else
            {
                input.y = (componentForward >= 0) ? 1 : -1;
            }
            
            // Vérifier si le bot est bloqué
            if (speed <= speedThreshold && input.y == 1 && speed > 0)
            {
                timeStuck += Time.deltaTime;
            }
            else
            {
                timeStuck = 0;
            }

            if (timeStuck >= stuckTimeThreshold)
            {
                StartCoroutine(ReverseForTime(reverseTime));
                timeStuck = 0;  // Réinitialiser le compteur de temps une fois la marche arrière initiée
            }
        }
        onInput?.Invoke(input);
    }
    
    IEnumerator ReverseForTime(float time)
    {
        isReversing = true;
        yield return new WaitForSeconds(time);
        isReversing = false;
    }

    void SelectWaypoint(Transform waypoint)
    {
        nextWaypoint = waypoint;
        // This "jitter" add a little randomness around the waypoint to make the AI slightly more human 
        nextWaypointPosition = nextWaypoint.position + new Vector3(Random.Range(-randomJitterOnPosition, randomJitterOnPosition), 0, Random.Range(-randomJitterOnPosition, randomJitterOnPosition));
    }
}
