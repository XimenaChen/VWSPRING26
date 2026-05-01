using UnityEngine;

public class RotateThenMove : MonoBehaviour
{
    [Header("Rotation")]
    public Vector3 targetRotation;     // 想旋转到的角度
    public float rotateSpeed = 60f;    // 旋转速度

    [Header("Movement")]
    public Vector3 moveDirection = Vector3.forward; // 移动方向
    public float moveDistance = 3f;    // 移动距离
    public float moveSpeed = 2f;       // 移动速度

    private Quaternion targetRot;
    private Vector3 startPos;
    private Vector3 targetPos;

    private bool finishedRotating = false;

    void Start()
    {
        targetRot = Quaternion.Euler(targetRotation);
        startPos = transform.position;
        targetPos = startPos + moveDirection.normalized * moveDistance;
    }

    void Update()
    {
        // 先旋转
        if (!finishedRotating)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRot,
                rotateSpeed * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, targetRot) < 0.1f)
            {
                finishedRotating = true;
            }
        }
        // 再移动
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
        }
    }
}