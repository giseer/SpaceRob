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
        
        Vector2 topLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        
        boxCollider.size = new Vector2(Screen.width, Screen.height);
        boxCollider.transform.position = new Vector2(topLeft.x + deadLineBorderOffsetFromScreen/2, topLeft.y + deadLineBorderOffsetFromScreen/2);
    }
    
    
}
