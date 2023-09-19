using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewControls : MonoBehaviour
{

    public Vector2 moveValue;    

    private InputPlayerActions ipa;

    private void Awake()
    {
        ipa = new InputPlayerActions();
        ipa.Player.Shoot.started += OnShoot;
        ipa.Player.Move.performed += OnMove;
        ipa.Player.Move.canceled += OnStopMove;
    }

    private void OnShoot(InputAction.CallbackContext c)
    {
        GetComponent<ShootingBehavior>().Shoot();
    }

    private void OnMove(InputAction.CallbackContext c)
    {
        moveValue = c.ReadValue<Vector2>();
    }

    private void OnStopMove(InputAction.CallbackContext c)
    {
        moveValue = Vector2.zero;
    }

    private void OnEnable()
    {
        ipa.Enable();
    }

    private void OnDisable()
    {
        ipa.Disable();
    }
}
