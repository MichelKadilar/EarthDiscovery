using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerControls : MonoBehaviour
{
    public UnityEvent<Vector2> onInput;

    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float backwardMoveSpeed;
    public float steerSpeed;

    private float inputX;
    private float inputY;

    void Update() // Get keyboard inputs
    {
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");

        Vector2 inputPlayer = new Vector2(inputX, inputY).normalized;
        onInput.Invoke(inputPlayer);
    }

}
