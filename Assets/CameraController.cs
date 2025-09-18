using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    InputSystem_Actions _input;
    
    private void Awake()
    {
        _input = new InputSystem_Actions();
      
    }


    private void OnEnable()
    {
        _input.Player.Enable();
    }
}
