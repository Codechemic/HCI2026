using TMPro;
using UnityEngine;

public class DrawButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI drawText;
    public bool isDrawing = false;

    int i = 0;

    public void Changebutton()
    {
        i = (i+1)%2;

        if (i==1){
            drawText.text = "stop";
            GameManager.instance.isDrawing = true;
            GameManager.instance.ShowMessage("start");
        }
        else{
            drawText.text = "Draw";
            GameManager.instance.isDrawing = false;
            GameManager.instance.ShowMessage("end");
        }
    }
}
