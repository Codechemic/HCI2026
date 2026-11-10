
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spherePrefab;
    public TextMeshProUGUI message;
    public Camera arCamera;

    public bool isDrawing = true;

    private Vector3 prevPosition;
    private bool hasPrevPosition = false;

    static GameManager m_instance;

    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager>();
            }
            return m_instance;
        }
    }

    public void ShowMessage(string text)
    {
        message.text = text;
        message.gameObject.SetActive(true);
    }

    private void Update()
    {
        DrawSpheres();
    }

    void DrawSpheres()
    {
        if (isDrawing == false)
        {
            hasPrevPosition = false;
            return;
        }

        if (spherePrefab == null || arCamera == null)
            return;

        Vector3 currentPosition = arCamera.ScreenToWorldPoint(
            new Vector3(Screen.width / 2f, Screen.height / 2f, 0.5f)
        );

        if (hasPrevPosition)
        {
            float distance = Vector3.Distance(
                currentPosition,
                prevPosition
            );

            if (distance < 0.3f)
                return;
        }

        GameObject go = Instantiate(
            spherePrefab,
            currentPosition,
            Quaternion.identity
        );

        go.transform.parent = transform;

        prevPosition = currentPosition;
        hasPrevPosition = true;
    }

    public void GameOver()
    {
        Application.Quit();
    }
}
