using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthPedestalInteractScript : MonoBehaviour
{

    void Start()
    {
    }

    // This method is called when another collider enters the object's collider
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Interacting with " + gameObject.name);
       InteractCoroutine();
    }

    void InteractCoroutine()
    {
        // Implement interaction logic here
        Debug.Log("Interacting with " + gameObject.name);
        SceneManager.LoadScene("Planet 3/Scenes/First Scene");
    }
}
