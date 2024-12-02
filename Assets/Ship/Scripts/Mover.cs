using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    
    public void Move(Vector2 movementValues)
    {
        // if (movementValues.y > 0)
        // {
        //     transform.position += transform.up * speed * Time.deltaTime;
        // }
        
        transform.position += new Vector3(movementValues.x, movementValues.y, 0f) * (speed * Time.deltaTime);
        
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
}
