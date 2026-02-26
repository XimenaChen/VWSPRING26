using UnityEngine;
using UnityEngine.UI;
using TMPro; // 如果使用TextMeshPro
using System.Collections;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI messageText;  // TextMeshPro 组件
    [TextArea(4,1)]
    public string fullMessage = "My head hurts... I feel like I'm going to die... I only remember my name and age.";  // 要显示的完整消息
    public Button wakeUpButton;
    public GameObject blackScreen;  // 黑色背景

    void Start()
    {
        messageText.text = "";
        StartCoroutine(TypeMessage());
        wakeUpButton.onClick.AddListener(OnWakeUp);
    }

    // 模拟打字机效果
    IEnumerator TypeMessage()
    {
        foreach (char letter in fullMessage.ToCharArray())
        {
            messageText.text += letter;
            yield return new WaitForSeconds(0.1f);  // 控制打字机速度
        }
    }

    // 点击醒来按钮后进入主场景
    void OnWakeUp()
    {
        blackScreen.SetActive(false);  // 隐藏黑屏
        // 你可以在这里加入更多的逻辑或过渡效果
        // 例如，加载新的场景：
        // SceneManager.LoadScene("MainScene");
    }
}
