using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    public Camera menuCamera;
    public Camera inGameCamera;
    public GameObject car; 
    public GameObject menuCanvas;
    public GameObject inGameCanvas;
    private CarController carController;

    private void Start()
    {
        // Obtient la référence au script CarController attaché à la voiture
        carController = car.GetComponent<CarController>();

        // Désactive le contrôleur de voiture et le son dès le début
        carController.enabled = false;

        // Active la caméra du menu et désactive la caméra in-game par défaut
        menuCamera.enabled = true;
        menuCamera.GetComponent<AudioListener>().enabled = true;
        inGameCamera.enabled = false;
        inGameCamera.GetComponent<AudioListener>().enabled = false;
        inGameCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
            menuCanvas.gameObject.SetActive(false);
            inGameCanvas.gameObject.SetActive(true);
            menuCamera.enabled = false;
            menuCamera.GetComponent<AudioListener>().enabled = false;
            inGameCamera.enabled = true;
            inGameCamera.GetComponent<AudioListener>().enabled = true;
            carController.enabled = true;
        }
    }

    private void ActivateMenuState()
    {
        menuCanvas.gameObject.SetActive(true);
        inGameCanvas.gameObject.SetActive(false);
        menuCamera.enabled = true;
        menuCamera.GetComponent<AudioListener>().enabled = true;
        inGameCamera.enabled = false;
        inGameCamera.GetComponent<AudioListener>().enabled = false;
        carController.enabled = false;
    }
}
