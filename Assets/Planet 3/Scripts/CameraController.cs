using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject planetCamera;

    void Start()
    {
        playerCamera.SetActive(true);
        planetCamera.SetActive(false);
    }
}