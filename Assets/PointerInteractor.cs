using UnityEngine;
using UnityEngine.InputSystem;

public class PointerInteractor : MonoBehaviour, IInteractionActivator
{
    private InputAction positionAction;

    private void OnEnable()
    {
        InputManager.Instance.actions.UI.LeftClick.performed += ProcessPointerAction;
        positionAction = InputManager.Instance.actions.UI.Position;
    }

    private void OnDisable()
    {
        InputManager.Instance.actions.UI.LeftClick.performed -= ProcessPointerAction;
        positionAction = null;
    }

    public void ProcessPointerAction(InputAction.CallbackContext context)
    {
        if (context.action.WasPressedThisFrame())
        {
            Vector2 pointerPosition = positionAction.ReadValue<Vector2>();
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(pointerPosition), out hit, 100f))
            {
                if (hit.transform.CompareTag("Interactable"))
                {
                    Interactable interactable = hit.transform.GetComponent<Interactable<Vector2>>();
                    interactable.Interact(
                }
                Debug.LogError(hit.transform.name);
            }
        }
    }
}
