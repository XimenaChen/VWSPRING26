using UnityEngine;

public class SpookyStatue : MonoBehaviour
{
    public Transform playerCamera;
    public float moveSpeed = 3.0f;
    public float stopDistance = 0.5f;
    public LayerMask obstacleLayer; // 在 Inspector 中选择墙壁所在的 Layer

    private void Update()
    {
        // 1. 计算是否在视野内
        Camera cam = playerCamera.GetComponent<Camera>();
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        Collider col = GetComponent<Collider>();
        bool isInFrustum = GeometryUtility.TestPlanesAABB(planes, col.bounds);

        // 2. 射线检测：检测是否被墙挡住 (Linecast)
        // 从怪物中心发向摄像机，如果打到东西且不是 Player，说明被挡住了
        bool isBlocked = Physics.Linecast(transform.position, playerCamera.position, ~obstacleLayer);

        // 3. 最终判断：如果 (没在视野内) 或者 (被墙挡住)，那就移动！
        if (!isInFrustum || isBlocked)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        float distance = Vector3.Distance(transform.position, playerCamera.position);
        if (distance > stopDistance)
        {
            Vector3 direction = (playerCamera.position - transform.position).normalized;
            direction.y = 0; // 锁定高度
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(playerCamera.position.x, transform.position.y, playerCamera.position.z));
            transform.Rotate(-90f,0,0);
        }
    }
}