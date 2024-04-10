using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public string sceneNameToLoad;

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a un tag spécifique, par exemple "Player"
        // Vous pouvez retirer cette vérification si vous voulez que tout objet déclenche le changement de scène
        if (other.CompareTag("Player"))
        {
            foreach (var go in SceneManager.GetSceneByName("First Scene").GetRootGameObjects())
            {
                Destroy(go);
            }
            SceneManager.LoadScene(sceneNameToLoad);
        }
        
    }
}
