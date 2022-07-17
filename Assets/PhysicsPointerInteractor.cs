using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsPointerInteractor : PointerInteractor
{
    public Action<RaycastHit> OnInteraction;

    protected override void ProcessPointerAction(InputAction.CallbackContext context)
    {
        if (context.action.WasPressedThisFrame())
        {
            Vector2 pointerPosition = positionAction.ReadValue<Vector2>();
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(pointerPosition), out hit, rayMaxDistance))
            {
                OnInteraction?.Invoke(hit);
            }
        }
    }
}
