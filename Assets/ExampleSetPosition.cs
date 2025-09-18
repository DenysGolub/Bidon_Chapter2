using UnityEngine;

public class ExampleSetPosition : MonoBehaviour
{
    public bool isLocal;
    public Vector3 toPosition;

    void Start()
    {
        if (isLocal)
        {
            Debug.Log("--- SET BY LOCAL POSITION ---");
            transform.localPosition = toPosition;
            Debug.Log($"Local Position: {transform.localPosition}");
            Debug.Log($"World  Position: {transform.position}");
            Debug.Log("--- ---");
        }
        else
        {
            Debug.Log("--- SET BY POSITION ---");
            transform.position = toPosition;
            Debug.Log($"World  Position: {transform.position}");
            Debug.Log($"Local Position: {transform.localPosition}");
            Debug.Log("--- ---");
        }

        if (transform.parent != null)
        {
            var p = transform.parent;
            Debug.Log($"Parent world pos: {p.position}, rot: {p.rotation.eulerAngles}, scale: {p.lossyScale}");
        }
    }
}
