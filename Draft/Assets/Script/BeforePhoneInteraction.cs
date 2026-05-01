using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class BeforePhoneInteraction : MonoBehaviour
{
    [Header("必须点击/抓取的 4 个目标物体")]
    public List<GameObject> targetObjects; 

    [Header("全部完成后触发")]
    public UnityEvent onAllTasksComplete;

    // 记录已经交互过的物体清单
    private HashSet<GameObject> completedObjects = new HashSet<GameObject>();

    /// <summary>
    /// VR 交互回调函数
    /// </summary>
    /// <param name="interactorObject">传入被选中的物体</param>
    public void OnObjectInteracted(GameObject interactorObject)
    {
        // 1. 判断该物体是否在名单内
        if (targetObjects.Contains(interactorObject))
        {
            // 2. 判断是否已经点击过
            if (!completedObjects.Contains(interactorObject))
            {
                completedObjects.Add(interactorObject);
                Debug.Log($"<color=green>任务进度: {completedObjects.Count} / {targetObjects.Count}</color>");

                // 3. 检查是否全部完成
                if (completedObjects.Count >= targetObjects.Count)
                {
                    onAllTasksComplete.Invoke();
                }
            }
        }
    }
}