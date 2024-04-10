using UnityEngine;
using UnityEngine.UI; // Pour accéder aux composants UI

public class UpdateWeatherIcon : MonoBehaviour
{
    public Image weatherIcon; // Assignez cela dans l'éditeur Unity
    public Sprite iconCloudy, iconCloudySunny, iconRain, iconLightning, iconSun;

    public void SetWeatherIcon(Weather[] weathers)
    {
        if (weathers.Length > 0)
        {
            var weatherMain = weathers[0].main;
            switch (weatherMain)
            {
                case "Clouds":
                    weatherIcon.sprite = weathers[0].description.Contains("few clouds") ? iconCloudySunny : iconCloudy;
                    break;
                case "Rain":
                    weatherIcon.sprite = iconRain;
                    break;
                case "Thunderstorm":
                    weatherIcon.sprite = iconLightning;
                    break;
                case "Clear":
                    weatherIcon.sprite = iconSun;
                    break;
                default:
                    Debug.Log("Météo non reconnue ou non supportée : " + weatherMain);
                    break;
            }
        }
    }
}