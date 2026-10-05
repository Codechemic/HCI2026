using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCubeSendMessage : MonoBehaviour
{
    private void OnMoveForward(InputValue value)
    {
        Debug.Log("########### OnMoveForward!");
    }

    private void OnMoveBack(InputValue value)
    {
        Debug.Log("########### OnMoveBack!");
    }

    private void OnMoveRight(InputValue value)
    {
        Debug.Log("########### OnMoveRight!");
    }

    private void OnMoveLeft(InputValue value)
    {
        Debug.Log("########### OnMoveLeft!");
    }
}