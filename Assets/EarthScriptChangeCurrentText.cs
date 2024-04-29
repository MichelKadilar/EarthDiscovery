using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScriptChangeCurrentText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // This method is called when another collider enters the object's collider
    void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("currentText", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
