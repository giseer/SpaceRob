using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootButton : MonoBehaviour
{
    [Header("Components")]
    // private Button buttonComponent;
    [SerializeField] private Shooter shooterShip;

    [Header("Values")] 
    private bool isHolding;

    private void Awake()
    {
        // buttonComponent = GetComponentInChildren<Button>();
    }

    public void OnPointerDown()
    {
        isHolding = true;
    }
    
    public void OnPointerUp()
    {
        isHolding = false;
    }

    private void Update()
    {
        if (isHolding)
        {
            PerformShot();    
        }
    }

    private void PerformShot()
    {
        shooterShip.Shoot();
    }

    private void OnDisable()
    {
        // buttonComponent.clicked -= PerformShot;
    }
}
