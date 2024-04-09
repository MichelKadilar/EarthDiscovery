using UnityEngine;
using UnityEngine.Events;
using Input = UnityEngine.Input;

public class PlayerControls : MonoBehaviour
{
    public UnityEvent<Vector2> onInput;

    private Vector2 inputPlayer;

    void Update()
    {
        float inputY = Input.GetAxisRaw("Vertical");
        float inputX = Input.GetAxisRaw("Horizontal");

        inputPlayer = new Vector2(inputX, inputY).normalized;
    }

    void FixedUpdate()
    {
        onInput.Invoke(inputPlayer);
    }
}
