using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerActions : MonoBehaviour
{
    InputMaster inputAction;

    Vector2 moveInput;

    private void Awake()
    {
        inputAction = new InputMaster();
        inputAction.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        float h = moveInput.x;
        float v = moveInput.y;
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}
