using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Toggle soundToggle; 

    void Start()
    {
        bool isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        soundToggle.isOn = isMuted;
        SetSound(!isMuted);
    }

    public void OnToggleSound(bool isMuted)
    {
        SetSound(!isMuted);
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void SetSound(bool soundState)
    {
        AudioListener.volume = soundState ? 1 : 0;
    }
}
