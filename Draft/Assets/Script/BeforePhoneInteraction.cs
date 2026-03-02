using UnityEngine;
using UnityEngine.Events;

public class BeforePhoneInteraction : MonoBehaviour
{
    public int targetCount = 4; // 目标点击次数
    private int currentCount = 0; // 当前计数
    
    [Header("完成后的触发事件")]
    public UnityEvent onAllObjectsSelected;

    // 当物体被点击时调用此方法
    public void ObjectClicked()
    {
        currentCount++;
        Debug.Log($"已点击物体数量: {currentCount}");

        if (currentCount >= targetCount)
        {
            onAllObjectsSelected.Invoke();
        }
    }
}