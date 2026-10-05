using UnityEngine;
using UnityEngine.UI;

public class ButtonEventMgr : MonoBehaviour
{
    [SerializeField] private Button testBtn;

    private void Awake()
    {
        if (testBtn != null)
        {
            // 클릭 이벤트(onClick) 발생 시 호출될 함수 OnButtonClick 등록
            testBtn.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        Debug.Log("Button Clicked");
    }

    private void OnDestroy()
    {
        if (testBtn != null)
        {
            // 오브젝트 파괴 시 리스너 해제 (메모리 누수 방지)
            testBtn.onClick.RemoveListener(OnButtonClick);
        }
    }
}