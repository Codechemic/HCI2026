
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private void Update()
    {
        // 자신의 플레이어만 조작
        if (!IsOwner)
            return;

        Vector2 input = Vector2.zero;

        // 키보드가 연결되어 있는지 확인
        if (Keyboard.current != null)
        {
            // WASD 입력
            if (Keyboard.current.wKey.isPressed)
                input.y += 1f;

            if (Keyboard.current.sKey.isPressed)
                input.y -= 1f;

            if (Keyboard.current.aKey.isPressed)
                input.x -= 1f;

            if (Keyboard.current.dKey.isPressed)
                input.x += 1f;
        }

        // 대각선 이동 속도 보정
        Vector3 movement = new Vector3(input.x, 0f, input.y);
        movement = Vector3.ClampMagnitude(movement, 1f);

        // 플레이어 이동
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
