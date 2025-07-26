using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField]
    private int rotationsPerMinute = 60;

    [SerializeField]
    [Tooltip("If False cube will rotate by using Quartenion, if True by using Euler Angle.")]
    private bool isQuaternion = true;

    private float _rotationSpeed;

    void Update()
    {
        _rotationSpeed = rotationsPerMinute * 360f / 60f;
        
        if(isQuaternion)
        {
            transform.rotation *= Quaternion.AngleAxis(_rotationSpeed * Time.deltaTime, new Vector3(30, 45, 60));
            Debug.Log($"Quartenion: {transform.rotation}");           
        }
        else
        {
            transform.eulerAngles += new Vector3(30, 45, 60) * Time.deltaTime * _rotationSpeed;
            Debug.Log($"Euler angles: {transform.eulerAngles}");
        }
    }
}
