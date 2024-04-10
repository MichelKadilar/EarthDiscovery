using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking; // Pour les requêtes web

public class WeatherAPI : MonoBehaviour
{
    public TextMeshProUGUI temperatureText;
    private readonly string baseUrl = "https://api.openweathermap.org/data/2.5/weather?q=";
    private readonly string apiKey = "d0731e8adaf7d6e7500b30240830f8a1"; // Remplacez par votre clé API

    public IEnumerator GetWeather(string city)
    {
        string url = $"{baseUrl}{city}&appid={apiKey}&units=metric";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Envoi de la requête et attente de la réponse
            yield return webRequest.SendWebRequest();

            if (UnityWebRequest.Result.ConnectionError == webRequest.result || UnityWebRequest.Result.ProtocolError == webRequest.result)
            {
                Debug.LogError("Erreur lors de l'accès à l'API météo: " + webRequest.error);
            }
            else
            {
                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(webRequest.downloadHandler.text);
                UpdateWeatherIcon updateWeatherIcon = FindObjectOfType<UpdateWeatherIcon>();
                updateWeatherIcon.SetWeatherIcon(weatherData.weather);
                temperatureText.text = $"{(int)weatherData.main.temp}°C";
                Debug.Log("Température à " + city + " : " + weatherData.main.temp + "°C");

            }
        }
    }
}

