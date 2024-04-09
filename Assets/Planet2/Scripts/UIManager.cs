using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text textLap;
    public Text winner;

    public void UpdateLapText(string message)
    {
        textLap.text = message;
    }

    public void UpdateWinnerText(string message)
    {
        winner.text = message;
    }
}
