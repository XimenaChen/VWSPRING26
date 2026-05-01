using UnityEngine;

public class AutoShow : MonoBehaviour
{
    public float showTime = 3f;

    void Start()
    {
        Invoke("Show", showTime);
    }

    void Show()
    {
        gameObject.SetActive(true);
    }
}   
  
