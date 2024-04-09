using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }
    public GameObject uiPanel; 
    public TextMeshProUGUI selectedCityText;
    public TextMeshProUGUI textMesh;
    private GameObject currentSelectedCity;

    private void Awake()
    {
        uiPanel.SetActive(false);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectCity(GameObject city, string cityName)
    {
        
        WeatherAPI weatherAPI = FindObjectOfType<WeatherAPI>();
        if (weatherAPI != null)
        {
            weatherAPI.StartCoroutine(weatherAPI.GetWeather(selectedCityText.text));
        }
        if (currentSelectedCity != null && currentSelectedCity != city)
        { 
            currentSelectedCity.GetComponent<InteractiveSphere>().Deselect();
        }

        if (currentSelectedCity != city)
        {
            currentSelectedCity = city;
            uiPanel.SetActive(true);
            selectedCityText.text = cityName; 
            city.GetComponent<InteractiveSphere>().Select();
            
        }
        else
        {
            DeselectCity();
            currentSelectedCity = null;
        }
    }

    public void DeselectCity()
    {
        if (currentSelectedCity != null)
        {
            currentSelectedCity.GetComponent<InteractiveSphere>().Deselect();
            selectedCityText.text = "";
            uiPanel.SetActive(false);
        }
    }

}