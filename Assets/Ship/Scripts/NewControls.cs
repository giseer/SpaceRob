using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NewControls : MonoBehaviour
{
    
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference shoot;

    [HideInInspector] public UnityEvent<Vector2> onMove;
    [HideInInspector] public UnityEvent onStopMove;
    [HideInInspector] public UnityEvent onShoot;
    
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
