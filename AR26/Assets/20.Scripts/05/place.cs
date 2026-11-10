using UnityEngine;

public class place : MonoBehaviour
{
    public gameObject marker;
    ARRaycastManager arRayManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arRayManager = GetComponent<ARRaycastManager>();
        marker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DetectGround();
    }

    public void DetectGround(){
        Vector2.screenCenter = new Vector2(Screen.width/2, Screen.height/2);
        
    }
}
