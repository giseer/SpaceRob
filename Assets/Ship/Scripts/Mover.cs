using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    
    private void Start()
    {
        rotationSpeed = 200f;
        speed = 2f;
    }
    
    public void Move(Vector2 movementValues)
    {
        if (movementValues.y > 0)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        
        Rotate(movementValues);
    }
    
    private void Rotate(Vector2 movementValues)
    {
        Vector3 newRotation = Vector3.zero;                                                         
        newRotation.z = movementValues.x;

        Quaternion newOrientation = Quaternion.Euler(newRotation * -rotationSpeed * Time.deltaTime);

        transform.rotation *= newOrientation;
    }
}
