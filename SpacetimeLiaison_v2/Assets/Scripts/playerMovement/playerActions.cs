using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerActions : MonoBehaviour
{
    InputMaster inputAction;

    Vector2 moveInput, smoothMouse;

    public Vector2 moveDelta;

    public float sensitivity, smoothing, maxSpeed;

    private Rigidbody thisRigid;

    private void Awake()
    {
        inputAction = new InputMaster();
        inputAction.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }

    private void Start()
    {
        thisRigid = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //float h = moveInput.x;
        //float v = moveInput.y;

        thisRigid.velocity = Vector3.ClampMagnitude(thisRigid.velocity, maxSpeed);
    }

    private void Update()
    {
        moveDelta = inputAction.Player.Move.ReadValue<Vector2>();

        moveDelta = Vector2.Scale(moveDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothMouse.x = Mathf.Lerp(smoothMouse.x, moveDelta.x, 1f / smoothing);
        smoothMouse.y = Mathf.Lerp(smoothMouse.y, moveDelta.y, 1f / smoothing);

        //thisRigid.velocity = new Vector3(moveDelta.x * sensitivity, thisRigid.velocity.y, moveDelta.y * sensitivity);
        thisRigid.velocity = new Vector3(smoothMouse.x * sensitivity, thisRigid.velocity.y, smoothMouse.y * sensitivity);

        //Debug.Log(thisRigid.velocity.magnitude);
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
