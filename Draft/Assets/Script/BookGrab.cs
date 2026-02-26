using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookGrab : MonoBehaviour
{
    public Transform snapPoint;  // 吸附点
    public float snapDistance = 0.5f;  // 吸附距离的阈值

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void Update()
    {
        // 检查距离吸附点是否足够接近，如果是则吸附
        if (Vector3.Distance(transform.position, snapPoint.position) < snapDistance)
        {
            SnapToPoint();
        }
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        // 如果抓取开始时不需要吸附，可以在这里添加其他逻辑
    }

    void SnapToPoint()
    {
        // 将书本的位置设置为吸附点的位置
        transform.position = snapPoint.position;
           // 设置书本的旋转为竖直方向
    transform.rotation = Quaternion.Euler(-90, 0, 0);
    }
}
