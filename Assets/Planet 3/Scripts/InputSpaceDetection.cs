using UnityEngine;

public class InputSpaceDetection : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject planetCamera;
    public Transform playerSpawnPoint;
    public GameObject player;
    public QuestManager questManager; // Assurez-vous que questManager est assigné dans l'inspecteur
    public Camera cameraMain;
    public GameObject spaceObject;
    public GameObject selectionObject;

    void Start()
    {
        // S'assurer que les objets sont dans leur état initial
        if (!cameraMain.isActiveAndEnabled)
        {
            player.transform.position = playerSpawnPoint.position;
        }
    }

    public void OnButtonPressed()
    {
        if (!cameraMain.isActiveAndEnabled && questManager.currentQuestIndex == 5)
        {
            PerformActions();
        }
        else if (!cameraMain.isActiveAndEnabled && questManager.currentQuestIndex > 5)
        {
            reset();
        }
    }

    public void PerformActions()
    {
        reset();
        questManager.CompleteCurrentQuest(); // Assurez-vous que cette méthode gère correctement l'index des quêtes
    }

    public void reset()
    {
        spaceObject.SetActive(false);
        selectionObject.SetActive(false);
        playerCamera.SetActive(true);
        planetCamera.SetActive(false);
    }
}