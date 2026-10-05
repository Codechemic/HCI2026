using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCubeEvent : MonoBehaviour
{
    public void OnPlayerMoveForward(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("########### OnPlayerMoveForward! Performed");
        }
    }
}