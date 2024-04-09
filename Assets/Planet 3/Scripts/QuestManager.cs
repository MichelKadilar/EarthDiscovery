using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI questText; // Affiche la description de la quête actuelle
    public TextMeshProUGUI questCounterText; // Affiche le compteur de progression (ex : "1/5")
    public GameObject spaceBarText;
    public List<string> questDescriptions; // Liste des descriptions d'objectifs
    public int currentQuestIndex = 0; // Index de l'objectif actuel

    void Start()
    {
        spaceBarText.SetActive(false);
        DisplayNextQuest();
    }
    void DisplayNextQuest()
        {
            if (currentQuestIndex >= questDescriptions.Count) return; // Tous les objectifs sont accomplis
            currentQuestIndex++;
            questText.text = questDescriptions[currentQuestIndex-1];
            questCounterText.text = $"{currentQuestIndex}/{questDescriptions.Count}";
            
        }
    
        public void CompleteCurrentQuest()
        {
            if (currentQuestIndex <= 0) return;
            if (currentQuestIndex == 4)
            {
                spaceBarText.SetActive(true);
            }
            Debug.Log("Quest completed: " + questDescriptions[currentQuestIndex - 1]);
            DisplayNextQuest(); // Affiche le prochain objectif
        }
}
