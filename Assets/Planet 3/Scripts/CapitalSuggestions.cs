using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CapitalSuggestions : MonoBehaviour
{
    public PlaceCapitals placeCapitals;
    public Button leftButton;
    public Button rightButton;
    public TextMeshProUGUI leftButtonText;
    public TextMeshProUGUI rightButtonText;
    public PlanetRotation planetRotation; // Assurez-vous d'ajouter une référence à votre script PlanetRotation

    private int currentCapitalIndex = 0;

    void Start()
    {
        if (placeCapitals.capitalNames.Count > 0)
        {
            UpdateButtonLabels();
        }
        else
        {
            Debug.LogError("La liste des noms des capitales est vide.");
        } 
    }

    public void SelectNextCapital()
    {
        currentCapitalIndex = (currentCapitalIndex + 1) % placeCapitals.capitalNames.Count;
        string nextCapital = placeCapitals.capitalNames[currentCapitalIndex];
        placeCapitals.SelectCapitalByName(nextCapital);
        UpdateButtonLabels();
    }

    public void SelectPreviousCapital()
    {
        currentCapitalIndex--;
        if (currentCapitalIndex < 0) currentCapitalIndex = placeCapitals.capitalNames.Count - 1;
        string prevCapital = placeCapitals.capitalNames[currentCapitalIndex];
        placeCapitals.SelectCapitalByName(prevCapital);
        UpdateButtonLabels();
    }

    void UpdateButtonLabels()
    {
        int nextIndex = (currentCapitalIndex + 1) % placeCapitals.capitalNames.Count;
        int prevIndex = currentCapitalIndex - 1 < 0 ? placeCapitals.capitalNames.Count - 1 : currentCapitalIndex - 1;

        leftButtonText.text = placeCapitals.capitalNames[prevIndex];
        rightButtonText.text = placeCapitals.capitalNames[nextIndex];
    }
}