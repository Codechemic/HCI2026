using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public void ProcessDifficultySelection(int selectValue)
    {
        if (selectValue >= 0 && selectValue < 4)
        {
            Debug.Log("Selected Index: " + selectValue);
        }
    }
}
