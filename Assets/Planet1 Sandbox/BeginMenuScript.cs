using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
