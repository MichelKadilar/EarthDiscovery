using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player"))
        {
            foreach (var go in SceneManager.GetSceneByName("First Scene").GetRootGameObjects())
            {
                Destroy(go);
            }
            SceneManager.LoadScene("Planet 4");
        }
        
    }
}
