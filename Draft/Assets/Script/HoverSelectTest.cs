using UnityEngine;
using TMPro;
using System.Collections;

public class HoverSelectText : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI hoverText;

    [TextArea(4, 2)] public string hoverMsg = "Hovering...";
    [TextArea(4, 2)] public string selectMsg = "Selected!";

    private bool isSelected = false;
    private bool isInCooldown = false; // 锁定状态位

    void Start()
    {
        if (panel != null) panel.SetActive(false);
    }

    public void OnHoverStart()
    {
        // 如果正在选中，或者处于“松开后的冷却期”，禁止显示 Hover
        if (isSelected || isInCooldown) return;

        UpdateUI(true, hoverMsg);
    }

    public void OnHoverEnd()
    {
        // 选中期间，射线离开不应该关掉 Panel
        if (isSelected) return;

        UpdateUI(false);
    }

    public void OnSelect()
    {
        StopAllCoroutines(); // 如果在冷却期内再次按下，取消冷却
        isInCooldown = false;
        
        isSelected = true;
        UpdateUI(true, selectMsg);
    }

    public void OnSelectExit()
    {
        isSelected = false;
        UpdateUI(false); // 先关掉

        // 开启 2 秒禁令
        StartCoroutine(CooldownTimer(2.0f)); 
    }

    private IEnumerator CooldownTimer(float duration)
    {
        isInCooldown = true;
        yield return new WaitForSeconds(duration);
        isInCooldown = false;
        
        // 冷却结束后，如果此时手柄还指着物体，可以手动检查一下是否需要恢复 Hover
        // 但通常 XR 系统会在你微动手柄时再次触发 OnHoverStart
    }

    private void UpdateUI(bool active, string msg = "")
    {
        if (panel == null) return;

        if (panel.activeSelf != active)
            panel.SetActive(active);

        if (active && hoverText != null)
            hoverText.text = msg;
    }
}