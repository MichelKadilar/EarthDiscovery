using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject questItemPrefab; // Le prefab de l'objectif
    public Transform questListPanel; // Le panneau qui contient les objectifs
    public Sprite checkSprite; // L'icône de vérification
    public List<string> questDescriptions; // Liste des descriptions d'objectifs
    public GameObject spaceBarText;
    public int currentQuestIndex = 0; // Index de l'objectif actuel

    void Start()
    {
        spaceBarText.SetActive(false);
        DisplayNextQuest();
    }

    void DisplayNextQuest()
    {
        if (currentQuestIndex >= questDescriptions.Count) return; // Tous les objectifs sont accomplis
        
        GameObject questItem = Instantiate(questItemPrefab, questListPanel);
        questItem.GetComponentInChildren<TextMeshProUGUI>().text = questDescriptions[currentQuestIndex];
        RectTransform rectTransform = questListPanel.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + 55); // Exemple d'ajustement

        currentQuestIndex++;
    }

    public void CompleteCurrentQuest()
    {
        if (currentQuestIndex <= 0) return;
        if (currentQuestIndex == 4)
        {
            spaceBarText.SetActive(true);
        }
        Transform lastQuestItem = questListPanel.GetChild(currentQuestIndex - 1);
        lastQuestItem.GetComponentInChildren<TextMeshProUGUI>().text = "<s>" + questDescriptions[currentQuestIndex - 1] + "</s>"; // Barrer le texte
        Image imageComponent = lastQuestItem.GetComponentInChildren<Image>(true);
        if(imageComponent != null)
        {
            imageComponent.sprite = checkSprite; // Changer l'image
        }
        else
        {
            Debug.LogError("Image component not found in lastQuestItem");
        }
        Debug.Log("Quest completed: " + questDescriptions[currentQuestIndex - 1]);
        DisplayNextQuest(); // Affiche le prochain objectif
    }
}