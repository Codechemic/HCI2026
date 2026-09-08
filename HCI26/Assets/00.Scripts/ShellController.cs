using UnityEngine;

public class ShellController : MonoBehaviour
{
    private float speed = 1000f;
    int lifetime = 5;

    private void start()
    {
        Shoot(transform.up);
    }
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir*speed);
        Destroy(GameObject)
    }
}
