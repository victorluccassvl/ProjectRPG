
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class NavigationPointerInteractor : PointerInteractor
{
    public Action<NavMeshHit> OnInteraction;

    protected override void ProcessPointerAction(InputAction.CallbackContext context)
    {
        if (context.action.WasPressedThisFrame())
        {
            Vector2 pointerPosition = positionAction.ReadValue<Vector2>();
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(pointerPosition), out hit, rayMaxDistance))
            {
                NavMeshHit navMeshHit;

                if (NavMesh.SamplePosition(hit.point, out navMeshHit, rayMaxDistance, ~0))
                {
                    OnInteraction?.Invoke(navMeshHit);
                }
            }
        }
    }
}
