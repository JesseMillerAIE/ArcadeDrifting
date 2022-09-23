using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    private Controls controls;

    public Vector2 MovementValue { get; private set; }
    public bool IsAccelerating { get; private set; }

    public bool IsBreaking { get; private set; }

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnAccelerate(InputAction.CallbackContext context)
    {
        if (context.performed) IsAccelerating = true; 
        else if (context.canceled) IsAccelerating = false;
    }

    public void OnHandbrake(InputAction.CallbackContext context)
    {
        if (context.performed) IsBreaking = true;
        else if (context.canceled) IsBreaking = false;
    }
}
