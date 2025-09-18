using UnityEngine;

public class RaycastAllTester : MonoBehaviour
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
            RaycastHit[] hits;

            if (useSphereCast)
            {
                hits = Physics.SphereCastAll(ray, sphereRadius, distance, LayerMask.GetMask("Target"));
            }
            else
            {
                hits = Physics.RaycastAll(ray, distance, LayerMask.GetMask("Target"));
            }

            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit hit = hits[i];
                    lastHitPoint = hit.point;
                    lastHitWasSuccess = true;

                    Debug.Log($"{hit.collider.name} has been destroyed!");
                    // Destroy(hit.collider.gameObject);
                     // Get the Renderer component from the new cube
                    var hitRenderer = hit.collider.GetComponent<Renderer>();

                    // Use SetColor to set the main color shader property
                    // hitRenderer.material.SetColor("_Color", Color.red);
                    // If your project uses URP, uncomment the following line and use it instead of the previous line
                    hitRenderer.material.SetColor("_BaseColor", Color.red);
                }
            }
            else
            {
                lastHitPoint = ray.origin + ray.direction * distance;
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
