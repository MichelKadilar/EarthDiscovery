using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
    }
}
