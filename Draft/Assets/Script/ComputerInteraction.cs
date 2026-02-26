using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ComputerInteraction : MonoBehaviour
{
    [Header("Panels")]
    public GameObject passwordPanel;      // 输入密码的面板
    public GameObject correctPanel;       // 正确密码面板
    public GameObject wrongPanel;         // 错误密码面板

    [Header("UI Elements")]
    public TMP_InputField passwordInput;  // 密码输入框
    public TMP_Text errorText;            // 错误文本提示
    public Button confirmButton;          // 确认按钮
    public Button closeButton;            // 关闭正确面板按钮
    public Button returnButton;           // 返回输入密码面板按钮

    [Header("XR Settings")]
    public GameObject spatialKeyboard;     // 将 XRI Spatial Keyboard 预制体拖到这里

    private string correctPassword = "BORDER"; // 正确的密码

    void Start()
    {
        // 初始状态
        passwordPanel.SetActive(false);
        correctPanel.SetActive(false);
        wrongPanel.SetActive(false);
        
        // 绑定按钮事件
        confirmButton.onClick.AddListener(ValidatePassword);
        closeButton.onClick.AddListener(CloseCorrectPanel);
        returnButton.onClick.AddListener(ReturnToPasswordPanel);

        // 如果你希望一开始键盘是隐藏的
        if (spatialKeyboard != null) spatialKeyboard.SetActive(false);
    }

    // 当玩家点击电脑（触发交互）时调用此方法
    public void OnPlayerSelect()
    {
        passwordPanel.SetActive(true);   
        wrongPanel.SetActive(false);     
        correctPanel.SetActive(false);   
        if (errorText != null) errorText.gameObject.SetActive(false); 
        
        passwordInput.text = "";
        
        // 激活 3D 键盘并让输入框获得焦点
        if (spatialKeyboard != null) spatialKeyboard.SetActive(true);
        passwordInput.ActivateInputField(); 
    }

    public void ValidatePassword()
    {
        // 注意：如果你在 InputField 设置了 Password 模式，这里读取 text 依然是明文，没问题
        if (passwordInput.text.Trim().ToUpper() == correctPassword)
        {
            // 成功：隐藏键盘和输入面板，显示成功面板
            if (spatialKeyboard != null) spatialKeyboard.SetActive(false);
            correctPanel.SetActive(true);
            passwordPanel.SetActive(false);
            wrongPanel.SetActive(false);
        }
        else
        {
            // 失败：跳转到错误面板
            passwordPanel.SetActive(false);
            wrongPanel.SetActive(true);
            if (errorText != null) 
            {
                errorText.text = "Incorrect password, please try again.";
                errorText.gameObject.SetActive(true);
            }
        }
    }

    // 补全缺失的函数 1：关闭正确面板
    public void CloseCorrectPanel()
    {
        correctPanel.SetActive(false);
    }

    // 补全缺失的函数 2：从错误面板返回输入面板
    public void ReturnToPasswordPanel()
    {
        wrongPanel.SetActive(false);
        passwordPanel.SetActive(true);
        passwordInput.text = "";
        passwordInput.ActivateInputField();
        if (spatialKeyboard != null) spatialKeyboard.SetActive(true);
    }
}