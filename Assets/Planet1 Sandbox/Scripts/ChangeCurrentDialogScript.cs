using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScript : MonoBehaviour
{

    public GameObject gameObject;
    public GameObject gameObject2;

    // Start is called before the first frame update
    void Start()
    {
        int currentText = PlayerPrefs.GetInt("currentText", 0);
        if (currentText == 0)
        {
            gameObject.SetActive(true);
            gameObject2.SetActive(false);
        }
        else if(currentText == 1)
        {
            gameObject.SetActive(false);
            gameObject2.SetActive(true);
        }

    }

}
