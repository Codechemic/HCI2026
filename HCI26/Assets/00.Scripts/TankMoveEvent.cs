
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoveEvent : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TankMove(InputAction.CallbackContext context)
    {
        float move = context.ReadValue<float>();

        if (Mathf.Abs(move) > 0.1f)
        {
            Vector3 moveDistance =
                transform.forward *
                move *
                moveSpeed *
                Time.deltaTime;

            rb.MovePosition(rb.position + moveDistance);
        }
    }

    public void TankRotate(InputAction.CallbackContext context)
    {
        float rotate = context.ReadValue<float>();

        if (Mathf.Abs(rotate) > 0.1f)
        {
            float turn =
                rotate *
                rotateSpeed *
                Time.deltaTime;

            Quaternion turnRotation =
                Quaternion.Euler(0f, turn, 0f);

            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}