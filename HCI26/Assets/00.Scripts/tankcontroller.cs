using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;

    private float moveInput;
    private float rotateInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 입력 받기 ("Vertical" 철자 수정)
        moveInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // 물리 연산 기반 이동 및 회전 처리
        MoveTank();
        RotateTank();
    }

    void MoveTank()
    {
        // 이동 거리 계산 및 적용 (MovePosition 사용)
        Vector3 moveDistance = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDistance);
    }

    void RotateTank()
    {
        // 회전각 계산 및 적용 (MoveRotation 사용)
        float turn = rotateInput * rotateSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}