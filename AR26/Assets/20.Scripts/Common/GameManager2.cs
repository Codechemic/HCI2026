using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    private static GameManager2 m_instance;

    public static GameManager2 instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager2>();
            }

            return m_instance;
        }
    }

    public void GameOver()
    {
        Application.Quit();
    }
}