using UnityEngine;

public class SphereCast : MonoBehaviour
{
    public float sphereRadius = 0.5f;
    public float maxDistance = 10f;
    public int sphereSteps = 10;

    private void OnDrawGizmosSelected()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.right.normalized;

        Gizmos.color = Color.cyan;

        for (int i = 0; i <= sphereSteps; i++)
        {
            float t = i / (float)sphereSteps;
            Vector3 pos = origin + direction * maxDistance * t;
            Gizmos.DrawWireSphere(pos, sphereRadius);
        }

        if (Physics.SphereCast(origin, sphereRadius, direction, out RaycastHit hit, maxDistance))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hit.point, sphereRadius);
        }
    }
}
