using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCubeCsharpEvent : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        if (context.action.name == "PlayerMoveForward" && context.phase == InputActionPhase.Performed)
        {
            Debug.Log("########### PlayerMoveForward C# Event Performed!");
        }
    }
}