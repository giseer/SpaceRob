using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;

    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}