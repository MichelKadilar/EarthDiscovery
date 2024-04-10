using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteractor : MonoBehaviour
{

    public Camera camera;
    public Camera camera2;
    public float waitSeconds;

    public bool isInteractable = true;

    void Start()
    {
        camera.enabled = true;
        camera2.enabled = false;
    }

    // This method is called when another collider enters the object's collider
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(InteractCoroutine());
    }

    IEnumerator InteractCoroutine()
    {
        // Implement interaction logic here
        Debug.Log("Interacting with " + gameObject.name);
        camera.enabled = !camera.enabled;
        camera2.enabled = !camera2.enabled;
        yield return new WaitForSeconds(waitSeconds);
        camera.enabled = !camera.enabled;
        camera2.enabled = !camera2.enabled;
    }
}
