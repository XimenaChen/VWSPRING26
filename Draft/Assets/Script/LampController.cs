using UnityEngine;

public class LampController : MonoBehaviour
{
    [SerializeField] private GameObject lightSource; // 在 Inspector 里把那个灯光物体拖进来

    // 初始状态下，确保灯光是关着的
    void Start()
    {
        if (lightSource != null)
            lightSource.SetActive(false);
    }

    // 供 XR Interaction Toolkit 调用的方法
    public void ToggleLamp()
    {
        if (lightSource != null)
        {
            // 取反当前状态：开 -> 关，关 -> 开
            lightSource.SetActive(!lightSource.activeSelf);
        }
    }
}