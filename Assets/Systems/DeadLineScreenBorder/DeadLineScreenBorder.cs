using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineScreenBorder : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    [Header("DeadLine Values")] 
    [SerializeField] private float deadLineBorderOffsetFromScreen; 
    
    private void Awake()
    {
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    private void Start()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Camera.main is null");
            return;    
        }

        Camera mainCamera = Camera.main;
        
        Vector2 topLeft = mainCamera.ViewportToWorldPoint(new Vector2(0, 1));
        Vector2 bottomRight = mainCamera.ViewportToWorldPoint(new Vector2(1, 0));
        
        boxCollider.size = new Vector2(
            (bottomRight.x - topLeft.x) + deadLineBorderOffsetFromScreen,
            (topLeft.y - bottomRight.y)+ deadLineBorderOffsetFromScreen);
        
    }

    public void CleanEnemiesOnScreen()
    {
        boxCollider.enabled = false;
        boxCollider.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Boost") && !other.CompareTag("player"))
        {
            Destroy(other.gameObject);
        }
    }
}
