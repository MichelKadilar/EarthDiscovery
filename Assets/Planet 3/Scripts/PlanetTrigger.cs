using UnityEngine;

public class PlanetTrigger : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject planetCamera;
    public GameObject spaceObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestManager questManager = FindObjectOfType<QuestManager>();
            if(questManager.currentQuestIndex == 1)
            {
                questManager.CompleteCurrentQuest();
            }
            spaceObject.SetActive(false);
            planetCamera.SetActive(true);
            playerCamera.SetActive(false);
        }
    }
}