using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractiveSphere : MonoBehaviour
{
    public TextMeshPro textMesh;
    private Vector3 originalScale;
    private Color originalColor;
    private Color orignalTextColor;
    private float originalFontSize;
    public Color hoverColor = Color.yellow;
    public Color selectedColor = Color.green;
    private bool isSelected = false;
    public Texture2D pointerCursor;

    void Start()
    {
        originalScale = transform.localScale;
        originalColor = GetComponent<Renderer>().material.color;
        orignalTextColor = textMesh.color;
        originalFontSize = textMesh.fontSize;
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(pointerCursor, Vector2.zero, CursorMode.Auto);
        if (!isSelected)
        {
            transform.localScale = originalScale * 2f; // Grossit le GameObject
            GetComponent<Renderer>().material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // Réinitialise le curseur par défaut

        if (!isSelected)
        {
            transform.localScale = originalScale; // Retour à la taille originale
            GetComponent<Renderer>().material.color = originalColor;
        }
    }
    void OnMouseDown()
    {
        SelectionManager.Instance.SelectCity(gameObject, textMesh.text);
    }

    public void Select()
    {
        isSelected = true;
        transform.localScale = originalScale * 2f;
        GetComponent<Renderer>().material.color = selectedColor;
        if (textMesh != null)
        {
            textMesh.color = Color.white;
        }
        QuestManager questManager = FindObjectOfType<QuestManager>();
        if(questManager.currentQuestIndex == 3 || questManager.currentQuestIndex == 4)
        {
            questManager.CompleteCurrentQuest();
        }
    }

    public void Deselect()
    {
        isSelected = false; // Met à jour le statut de sélection
        transform.localScale = originalScale;
        GetComponent<Renderer>().material.color = originalColor;
        if (textMesh != null)
        {
            textMesh.color = orignalTextColor;
        }
    }




}
