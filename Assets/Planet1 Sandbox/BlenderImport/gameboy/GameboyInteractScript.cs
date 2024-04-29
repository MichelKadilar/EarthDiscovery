using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameboyInteractScript : MonoBehaviour
{

    public Camera camera;
    public float waitSeconds;
    public Animator animator;
    public GameObject gameObject;

    public bool isInteractable = true;
    public bool hasBeenInteractedWith = false;

    void Start()
    {
        camera.enabled = false;
        hasBeenInteractedWith = false;
    }

    // This method is called when another collider enters the object's collider
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(InteractCoroutine());
        Time.timeScale = 1;
    }

    IEnumerator InteractCoroutine()
    {
        // Implement interaction logic here
        Debug.Log("Interacting with " + gameObject.name);
        camera.enabled = true;
        animator.SetTrigger("hasBeenInteractedWith");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Planet2/Planet2Scene");
        asyncLoad.allowSceneActivation = false;
        while (asyncLoad.progress < 0.9f)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");
            yield return null;
        }
        asyncLoad.allowSceneActivation = true;
        camera.enabled = false;
        hasBeenInteractedWith = false;
        //gameObject.SetActive(false);
    }
}
