using UnityEngine;

public class AutoHide : MonoBehaviour
{
    public float hideTime = 3f;

    void Start()
    {
        Invoke("Hide", hideTime);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}