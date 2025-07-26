using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField]
    Vector3 directionA;

    [SerializeField]
    Vector3 directionB;

    private void Start()
    {
        transform.position = directionA;       
    }

    void Update()
    {
        Vector3 normalizedDirection = (directionB - directionA).normalized * Time.deltaTime;
        Debug.Log(normalizedDirection);
        transform.position += normalizedDirection;
    }
}
