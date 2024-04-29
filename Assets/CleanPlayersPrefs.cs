using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanPlayersPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
