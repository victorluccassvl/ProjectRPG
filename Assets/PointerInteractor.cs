using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PointerInteractor : MonoBehaviour
{
    protected InputAction positionAction;
    protected float rayMaxDistance = 100f;

    protected virtual void OnEnable()
    {
        InputManager.Instance.actions.UI.LeftClick.performed += ProcessPointerAction;
        positionAction = InputManager.Instance.actions.UI.Position;
    }

    protected virtual void OnDisable()
    {
        InputManager.Instance.actions.UI.LeftClick.performed -= ProcessPointerAction;
        positionAction = null;
    }

    protected abstract void ProcessPointerAction(InputAction.CallbackContext context);
}