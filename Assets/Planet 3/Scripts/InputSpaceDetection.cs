using UnityEngine;

public class InputSpaceDetection : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject planetCamera;
    public Transform playerSpawnPoint;
    public GameObject player;
    public QuestManager questManager;
    public Camera cameraMain;
    public GameObject spaceObject;
    public GameObject selectionObject;
    void Update()
    {
        if (!cameraMain.isActiveAndEnabled)
        {
            player.transform.position = playerSpawnPoint.position;
        }
        if (!cameraMain.isActiveAndEnabled && Input.GetKeyDown(KeyCode.Space))
        {
            player.transform.position = playerSpawnPoint.position;
            if (questManager.currentQuestIndex == 5)
            {
                PerformActions();
            }
            else if (questManager.currentQuestIndex > 5)
            {
                reset();
            }
        }
    }

    void PerformActions()
    {
        reset();
        questManager.CompleteCurrentQuest();
    }

    void reset()
    {
        spaceObject.SetActive(false);
        selectionObject.SetActive(false);
        playerCamera.SetActive(true);
        planetCamera.SetActive(false);
    }
}