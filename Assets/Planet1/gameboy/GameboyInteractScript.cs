using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameboyInteractScript : MonoBehaviour
{

    public Camera camera;
    public float waitSeconds;
    public Animator animator;

    public bool isInteractable = true;

    void Start()
    {
        camera.enabled = false;
    }

    // This method is called when another collider enters the object's collider
    void OnTriggerEnter(Collider other)
    {
        camera.enabled = true;
        InteractCoroutine();
    }

    void InteractCoroutine()
    {
        // Implement interaction logic here
        Debug.Log("Interacting with " + gameObject.name);
        camera.enabled = !camera.enabled;
        animator.SetTrigger("OnPlayerInteraction");
        camera.enabled = !camera.enabled;
        SceneManager.LoadScene("Planet2/Planet2Scene");
    }
}
