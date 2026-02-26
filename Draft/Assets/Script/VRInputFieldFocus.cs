using UnityEngine;
using TMPro; // 如果你用的是 TextMeshPro 的话
//using UnityEngine.UI; // 如果使用普通的 UI 输入框

public class VRInputFieldFocus : MonoBehaviour
{
    public TMP_InputField inputField; // 你的 InputField
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor; // VR 控制器的 Ray Interactor

    void Update()
    {
        // 如果射线交互器正在指向 InputField，设置焦点
        if (rayInteractor != null && rayInteractor.hasSelection)
        {
            inputField.Select();  // 使 InputField 获取焦点
        }
    }
}
