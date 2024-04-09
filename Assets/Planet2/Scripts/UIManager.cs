using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text textLap;

    public void UpdateLapText(string message)
    {
        textLap.text = message;
    }
}
