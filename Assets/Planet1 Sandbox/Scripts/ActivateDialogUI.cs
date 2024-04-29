using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogUI : MonoBehaviour
{
    public GameObject gameObject;

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(true);
        Debug.Log(gameObject);
    }
}
