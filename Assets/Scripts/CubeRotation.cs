using Unity.Mathematics;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField]
    private int rotationsPerMinute = 60;

    [SerializeField]
    [Tooltip("If False cube will rotate by using Quartenion, if True by using Euler Angle.")]
    private bool isQuaternion = true;
    
    private float _rotationSpeed;
    private int rotationCounter;
    private Quaternion previousRotation;
    private float angle;


    void Start()
    {
        previousRotation = this.transform.rotation;
    }

    void Update()
    {
        _rotationSpeed = rotationsPerMinute * 360f / 60f;

        if (isQuaternion)
        {
            transform.rotation *= Quaternion.AngleAxis(_rotationSpeed * Time.deltaTime, Vector3.up);
            // Debug.Log($"Quartenion: {transform.rotation}");
        }
        else
        {
            transform.Rotate(0f, Time.deltaTime * _rotationSpeed, 0f);
            // Debug.Log($"Euler angles: {transform.eulerAngles}");
        }

        angle += Quaternion.Angle(transform.rotation, previousRotation);
        previousRotation = this.transform.rotation;

        if (angle >= 360)
        {
            rotationCounter++;
            angle = 0;
            if (isQuaternion)
            {
                Debug.Log($"Обертання квартеріона: {rotationCounter}");
            }
            else
            {
                Debug.Log($"Обертання Ейлера: {rotationCounter}");
            }
        }
        
    }
}
