using UnityEngine;
using TMPro;
//using UnityEngine.UI;  // 导入 UI 命名空间

public class InputFieldDebug : MonoBehaviour
{
    public TMP_InputField inputField;

    void Update()
    {
        if (inputField.isFocused)
        {
            Debug.Log("InputField is focused.");
        }
        else
        {
            Debug.Log("InputField is not focused.");
        }
    }
}