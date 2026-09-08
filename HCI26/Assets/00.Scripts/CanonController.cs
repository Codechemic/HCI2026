using UnityEngine;

public class CanonController : MonoBehaviour
{
    public GameObject shellPrefabs;
    public Transform firetrans;
    
    GameObject shell;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shell = Instantiate(shellPrefabs, firetrans.position, firetrans.rotation);
            shell.GetComponent<ShellController>().Shoot(transform.up);
        }
    }
}
