using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public Transform player;
    public float viewAngle = 60f;
    public float rotationSpeed = 2f;
    public float viewDistance = 10f;

    void Update()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;

        float dot = Vector3.Dot(transform.forward, toPlayer);
        float threshold = Mathf.Cos(viewAngle * Mathf.Deg2Rad);

        Debug.Log($"[DOT] Значення dot: {dot:F2}, поріг: {threshold:F2}");

        if (dot > threshold)
        {
            Debug.Log("[VIEW] Гравець у полі зору");

            float crossY = Vector3.Cross(transform.forward, toPlayer).y;
            Debug.Log($"[CROSS] Значення cross.y: {crossY:F2}");

            if (Mathf.Abs(crossY) > 0.01f)
            {
                float direction = Mathf.Sign(crossY);
                string turnDir = direction > 0 ? "вліво" : "вправо";

                Debug.Log($"[TURN] Поворот {turnDir}");

                transform.Rotate(0f, direction * rotationSpeed * Time.deltaTime * 60f, 0f);
            }
            else
            {
                Debug.Log("[TURN] Ворог вже дивиться на гравця, не обертається");
            }
        }
        else
        {
            Debug.Log("[VIEW] Гравець поза полем зору — ігнор");
        }
    }

    void OnDrawGizmos()
    {
        if (player == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);

        Vector3 leftLimit = Quaternion.Euler(0, -viewAngle, 0) * transform.forward;
        Vector3 rightLimit = Quaternion.Euler(0, viewAngle, 0) * transform.forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, leftLimit * viewDistance);
        Gizmos.DrawRay(transform.position, rightLimit * viewDistance);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, player.position);

        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(player.position, player.forward * 2f);
    }
}
