using UnityEngine;

using System.Collections.Generic;

public class PhoneInteractionTrigger : MonoBehaviour
{
    [Header("需要被解锁的物体列表")]
    public List<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable> objectsToUnlock;

    void Start()
    {
        // 游戏一开始，循环列表，把所有物体的交互组件都关掉
        foreach (var obj in objectsToUnlock)
        {
            if (obj != null)
            {
                obj.enabled = false; 
            }
        }
    }

    // 这个方法就是“钥匙”，由手机触发
    public void EnableAllInteractions()
    {
        foreach (var obj in objectsToUnlock)
        {
            if (obj != null)
            {
                obj.enabled = true;
            }
        }
        Debug.Log("手机已选中！所有物体交互已激活。");
    }
}