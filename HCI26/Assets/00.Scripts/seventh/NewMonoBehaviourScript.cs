using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 moveDir = transform.forward * Time.fixedDeltaTime * speed;
        rb.MovePosition(rb.position + moveDir);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}