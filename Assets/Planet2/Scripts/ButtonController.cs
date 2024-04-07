using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] // S'assure que ce script s'attache uniquement aux GameObjects qui ont un composant Button.
public class ButtonController : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (true)
        {
            button.interactable = !GameManager.Instance.isInGame;
        }
    }
}
