
using UnityEngine.Events;
using UnityEngine;

public class SimpleCheckpoint : MonoBehaviour
{
    public UnityEvent<GameObject, SimpleCheckpoint> onCheckpointEnter;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            onCheckpointEnter.Invoke(collider.gameObject, this);
        }
    }
}