using UnityEngine;

public class SimpleRaycast : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.red);
        }
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out RaycastHit hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.green);
            Debug.Log($"{hit.collider.name} hit!");
        }
    }
}
