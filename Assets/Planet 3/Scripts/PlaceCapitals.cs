using System.Collections.Generic;
using UnityEngine;
using TMPro; // Assurez-vous d'inclure l'espace de nom pour TextMesh Pro
using System.Globalization;

public class PlaceCapitals : MonoBehaviour
{
    public GameObject capitalMarkerPrefab;
    public GameObject capitalTextPrefab;
    public TextAsset csvFile;
    public List<string> capitalNames = new List<string>(); // Liste pour stocker les noms des capitales
    public List<Vector3> capitalPositions = new List<Vector3>(); // Liste pour stocker les positions des capitales
    public Dictionary<string, InteractiveSphere> capitalsDictionary = new Dictionary<string, InteractiveSphere>();


    void Awake()
    {
        Place();
    }

    void Place()
    {
        string[] lines = csvFile.text.Replace("\r\n", "\n").Split('\n');

        for (int i = 1; i < lines.Length; i++) // Commence à 1 pour ignorer l'en-tête
        {
            if (string.IsNullOrEmpty(lines[i])) continue; // Ignore les lignes vides

            string[] data = lines[i].Split(',');
            
            if (data.Length < 6 || string.IsNullOrEmpty(data[1]) || string.IsNullOrEmpty(data[2]) || string.IsNullOrEmpty(data[3]))
            {
                Debug.LogWarning($"Ligne {i} ignorée en raison de données manquantes ou malformées.");
                continue;
            }

            if (float.TryParse(data[2], NumberStyles.Any, CultureInfo.InvariantCulture, out float latitude) && 
                float.TryParse(data[3], NumberStyles.Any, CultureInfo.InvariantCulture, out float longitude))
            {
                Vector3 position = LatLongToPositionOnSphere(latitude, longitude, transform.localScale.x * 0.96f) + transform.position;
                GameObject markerInstance = Instantiate(capitalMarkerPrefab, position, Quaternion.identity, transform);
                InteractiveSphere interactiveSphere = markerInstance.GetComponent<InteractiveSphere>();
                if(interactiveSphere != null) {
                    capitalsDictionary.Add(data[1], interactiveSphere);
                }
                else
                {
                    Debug.LogError("InteractiveSphere component not found on markerInstance for " + data[1]);
                    continue;
                }

                GameObject textMeshObj = Instantiate(capitalTextPrefab, position + new Vector3(0, 0.35f, 0), Quaternion.identity, transform);
                TextMeshPro textMesh = textMeshObj.GetComponent<TextMeshPro>();
                if (textMesh == null)
                {
                    Debug.LogError("TextMeshPro component not found on textMeshObj for " + data[1]);
                    continue;
                }

                textMesh.text = data[1];
                interactiveSphere.textMesh = textMesh; // Now we're sure both components exist
                capitalNames.Add(data[1]);
                capitalPositions.Add(position);
            }
        }
    }

    Vector3 LatLongToPositionOnSphere(float latitude, float longitude, float radius)
    {
        latitude *= Mathf.Deg2Rad;
        longitude *= Mathf.Deg2Rad;
        float x = radius * Mathf.Cos(latitude) * Mathf.Cos(longitude);
        float y = radius * Mathf.Sin(latitude);
        float z = radius * Mathf.Cos(latitude) * Mathf.Sin(longitude);
        return new Vector3(x, y, z);
    }
    public Vector3 GetCapitalPosition(string capitalName)
    {
        int index = capitalNames.IndexOf(capitalName);
        if (index != -1)
        {
            return capitalPositions[index];
        }
        return Vector3.zero; // Retourne une position par défaut si la capitale n'est pas trouvée
    }
    public void SelectCapitalByName(string capitalName)
    {
        if (capitalsDictionary.TryGetValue(capitalName, out InteractiveSphere sphere))
        {
            SelectionManager.Instance.SelectCity(sphere.gameObject, capitalName);
        }
    }

}
