
using UnityEngine.Events;
using UnityEngine;

public class SimpleCheckpoint : MonoBehaviour
{
    public UnityEvent<CarIdentity, SimpleCheckpoint> onCheckpointEnter;

    void OnTriggerEnter(Collider collider)
    {
        CarIdentity carIdentity = collider.GetComponent<CarIdentity>();
        if (carIdentity != null)
        {
            onCheckpointEnter.Invoke(carIdentity, this);
        }
    }
}