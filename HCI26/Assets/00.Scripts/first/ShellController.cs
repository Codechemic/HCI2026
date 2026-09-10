using UnityEngine;

public class ShellController : MonoBehaviour
{
    private float speed = 1000f;
    [SerializeField] private int lifetime = 5;

    // 1. 유니티 라이프사이클 메서드는 대문자 Start로 작성해야 합니다.
    private void Start()
    {
        Shoot(transform.up);
    }

    public void Shoot(Vector3 dir)
    {
        // Rigidbody 이동 처리
        GetComponent<Rigidbody>().AddForce(dir * speed);

        // 2. Destroy 문법 수정 및 lifetime 후 자동 파괴 설정 (gameObject는 소문자 g)
        Destroy(gameObject, lifetime);
    }
}