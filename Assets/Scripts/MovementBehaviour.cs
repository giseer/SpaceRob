using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update

    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}