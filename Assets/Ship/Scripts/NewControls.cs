using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NewControls : MonoBehaviour
{
    [Header("PC Settings")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference shoot;

    [HideInInspector] public UnityEvent<Vector2> onMove;
    [HideInInspector] public UnityEvent onStopMove;
    [HideInInspector] public UnityEvent onShoot;
    
    [Header("Mobile Settings")]
    [SerializeField] private Joystick joystick;
    
    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();
    }

    private void FixedUpdate()
    {
        if (move.action.IsPressed())
        {
            onMove.Invoke(move.action.ReadValue<Vector2>());
        }
        else
        {
            onStopMove.Invoke();
        }

        if (joystick.Direction != Vector2.zero)
        {
            onMove.Invoke(joystick.Direction);
        }

        if (shoot.action.IsPressed())
        {
            onShoot.Invoke();
        }
    }

    private void OnDisable()
    {
        move.action.Disable();
        shoot.action.Disable();
    }
}
