using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI; // 如果你要控制按钮显示，需要这个

public class BedInteraction : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI hoverText;
    public GameObject eatPillButton; // 在 Inspector 里把那个“吃药”按钮拖进来

    [TextArea(2, 2)] public string notTimeMsg = "This is not the time to sleep.";
    [TextArea(2, 2)] public string timeToSleepMsg = "Time to sleep! Do you want to take the pill?";

    // 关键状态：CorrectPane 是否已经打开
    public bool isCorrectPaneOpened = false; 

    private bool isSelected = false;
    private bool isInCooldown = false;

    void Start()
    {
        if (panel != null) panel.SetActive(false);
        if (eatPillButton != null) eatPillButton.SetActive(false); // 默认隐藏按钮
    }

    // 提供一个公有方法，让你的 CorrectPane 在打开时调用这个
    public void SetCorrectPaneOpened()
    {
        isCorrectPaneOpened = true;
    }

    public void OnHoverStart()
    {
        if (isSelected || isInCooldown) return;
        
        // 根据状态显示不同的 Hover 提示
        string msg = isCorrectPaneOpened ? "Ready to sleep" : "Bed";
        UpdateUI(true, msg);
    }

    public void OnHoverEnd()
    {
        if (isSelected) return;
        UpdateUI(false);
    }

    public void OnSelect()
    {
        StopAllCoroutines();
        isInCooldown = false;
        isSelected = true;

        if (!isCorrectPaneOpened)
        {
            // 情况 A：还没打开 CorrectPane
            UpdateUI(true, notTimeMsg);
            if (eatPillButton != null) eatPillButton.SetActive(false);
        }
        else
        {
            // 情况 B：已经打开过 CorrectPane，显示吃药询问
            UpdateUI(true, timeToSleepMsg);
            if (eatPillButton != null) eatPillButton.SetActive(true); 
        }
    }

    public void OnSelectExit()
    {
        isSelected = false;
        // 如果你希望选中离开后 UI 消失，取消下面注释
        // UpdateUI(false); 
        // if (eatPillButton != null) eatPillButton.SetActive(false);

        StartCoroutine(CooldownTimer(1.0f)); 
    }

    private IEnumerator CooldownTimer(float duration)
    {
        isInCooldown = true;
        yield return new WaitForSeconds(duration);
        isInCooldown = false;
    }

    private void UpdateUI(bool active, string msg = "")
    {
        if (panel == null) return;
        panel.SetActive(active);
        if (active && hoverText != null) hoverText.text = msg;
    }
}