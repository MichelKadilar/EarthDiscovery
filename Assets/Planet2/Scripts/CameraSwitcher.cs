using System;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera menuCamera;
    public Camera inGameCamera;
    public GameObject car; 
    public AudioSource carAudio;
    public AudioSource backgroundMusic;

    private CarController carController;

    private void Start()
    {
        if(GameManager.Instance) GameManager.Instance.isInGame = false;

        // Obtient la référence au script CarController attaché à la voiture
        carController = car.GetComponent<CarController>();

        // Désactive le contrôleur de voiture et le son dès le début
        carController.enabled = false;
        carAudio.enabled = false;

        // Active la caméra du menu et désactive la caméra in-game par défaut
        menuCamera.enabled = true;
        menuCamera.GetComponent<AudioListener>().enabled = true;
        inGameCamera.enabled = false;
        inGameCamera.GetComponent<AudioListener>().enabled = false;
        backgroundMusic.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // && GameManager.Instance.isInGame
        {
            ActivateMenuState();
        }
    }

    public void ToggleCameraAndControl()
    {
        if (inGameCamera.enabled)
        {
            ActivateMenuState();
        }
        else
        {
            if (GameManager.Instance) GameManager.Instance.isInGame = true;
            menuCamera.enabled = false;
            menuCamera.GetComponent<AudioListener>().enabled = false;
            inGameCamera.enabled = true;
            inGameCamera.GetComponent<AudioListener>().enabled = true;
            carController.enabled = true;
            carAudio.enabled = true;
            backgroundMusic.Stop();
        }
    }

    private void ActivateMenuState()
    {
        if (GameManager.Instance) GameManager.Instance.isInGame = false;
        menuCamera.enabled = true;
        menuCamera.GetComponent<AudioListener>().enabled = true;
        inGameCamera.enabled = false;
        inGameCamera.GetComponent<AudioListener>().enabled = false;
        carController.enabled = false;
        carAudio.enabled = false; 
        backgroundMusic.Play();
    }
}
