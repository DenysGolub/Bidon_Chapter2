using UnityEngine;

public class RaycastTester : MonoBehaviour
{
    public float distance = 100f;
    public float sphereRadius = 0.5f;
    public bool useSphereCast = false;

    private Vector3? lastHitPoint = null;
    private Vector3 lastHitNormal;
    private bool lastHitWasSuccess;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isHit;

            if (useSphereCast)
            {
                isHit = Physics.SphereCast(ray, sphereRadius, out hit, distance, LayerMask.GetMask("Target"));
            }
            else
            {
                isHit = Physics.Raycast(ray, out hit, distance, LayerMask.GetMask("Target"));
            }

            if (isHit)
            {

                Debug.Log("Hit: " + hit.collider.name);
                Destroy(hit.collider.gameObject);
                Debug.DrawLine(ray.origin, hit.point, Color.green, 2f);
                lastHitPoint = hit.point;
                lastHitNormal = hit.normal;
                lastHitWasSuccess = true;
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 2f);
                lastHitPoint = ray.origin + ray.direction * distance;
                lastHitNormal = ray.direction;
                lastHitWasSuccess = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (lastHitPoint.HasValue)
        {
            if (useSphereCast)
            {
                Gizmos.color = lastHitWasSuccess ? Color.green : Color.red;
                Gizmos.DrawWireSphere(lastHitPoint.Value, sphereRadius);
            }
            else
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(lastHitPoint.Value, lastHitNormal.normalized * 0.5f);
            }
        }
    }
}
