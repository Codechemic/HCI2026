using UnityEngine;
using TMPro;

public class drawbuttoncontroller : MonoBehaviour
{
    public TextMeshProUGUI drawtext;

    int i = 0;
    public void changenode()
    {
        i = (i + 1) % 2;
        if (i == 1)
        {
            drawtext.text = "stop";
        }
        else
        {
            drawtext.text = "start";
        }
    }
}