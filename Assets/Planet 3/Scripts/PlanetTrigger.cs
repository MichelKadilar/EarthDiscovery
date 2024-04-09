using UnityEngine;

public class PlanetTrigger : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject planetCamera;
    public GameObject spaceObject;
    public GameObject firstPlane;
    public GameObject secondPlane;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestManager questManager = FindObjectOfType<QuestManager>();
            Debug.Log("Quest index: " + questManager.currentQuestIndex);
            spaceObject.SetActive(questManager.currentQuestIndex>1);
            if(questManager.currentQuestIndex == 1)
            {
                MovePlane movePlane = FindObjectOfType<MovePlane>();
                firstPlane.SetActive(false);
                secondPlane.SetActive(true);
                questManager.CompleteCurrentQuest();
            }
            planetCamera.SetActive(true);
            playerCamera.SetActive(false);
        }
    }
}