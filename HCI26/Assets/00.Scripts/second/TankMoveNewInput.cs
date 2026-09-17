using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoveNewInput : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue Value)
    {
        float move = Value.Get<float>();

        if (Mathf.Abs(move) > 0.1f)
        {
            Vector3 moveDistance =
                transform.forward *
                move *
                moveSpeed *
                Time.fixedDeltaTime;

            rb.MovePosition(rb.position + moveDistance);
        }
    }

    void OnRotate(InputValue Value)
    {
        float rotate = Value.Get<float>();

        if (Mathf.Abs(rotate) > 0.1f)
        {
            float turn =
                rotate *
                rotateSpeed *
                Time.fixedDeltaTime;

            Quaternion turnRotation =
                Quaternion.Euler(0f, turn, 0f);

            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}