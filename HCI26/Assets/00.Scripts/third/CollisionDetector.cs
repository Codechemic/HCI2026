using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Collision Event (물리적 충돌 감지)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter : " + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay : " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit : " + collision.gameObject.name);
    }

    // Trigger Event (통과형 영역 감지)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter : " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay : " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit : " + other.gameObject.name);
    }
}