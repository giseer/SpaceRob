using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Speed Values")]
    public float speed;
    public float rotationSpeed;
    
    [Header("Limits Values")]
    [SerializeField] ScreenLimits limits;
    private Vector2 screenBounds;

    private void Start()
    {
        if (limits != null)
        {
            screenBounds = limits.GetScreenLimitsSize() / 2f;
        }
        else
        {
            Debug.LogError("ScreenLimits no está asignado.");
        }
    }

    public void Move(Vector2 movementValues)
    {
        transform.position += new Vector3(movementValues.x, movementValues.y, 0f) * (speed * Time.deltaTime);
        
        RestrictToScreenBounds();
        
        Rotate(movementValues);
    }
    
    private void Rotate(Vector2 movementValues)
    {
        Vector2 desiredDirection = movementValues.normalized;
        
        float targetAngle = Mathf.Atan2(desiredDirection.y, desiredDirection.x) * Mathf.Rad2Deg - 90f;
        float currentAngle = transform.eulerAngles.z;
        float smoothedAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, smoothedAngle);
    }
    
    private void RestrictToScreenBounds()
    {
        try
        {
            Vector3 position = transform.position;
        
            position.x = Mathf.Clamp(position.x, -screenBounds.x, screenBounds.x);
            position.y = Mathf.Clamp(position.y, -screenBounds.y, screenBounds.y);
        
            transform.position = position;
        }
        catch (Exception lim)
        {
            Debug.LogError(lim);
            throw;
        }
    }
}
