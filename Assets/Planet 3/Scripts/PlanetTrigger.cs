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
            Debug.Log("Quest index: " + questManager.currentQuestIndex);
            spaceObject.SetActive(questManager.currentQuestIndex>1);
            if(questManager.currentQuestIndex == 1)
            {
                questManager.CompleteCurrentQuest();
            }
            planetCamera.SetActive(true);
            playerCamera.SetActive(false);
        }
    }
}