using System;
using UnityEngine;

public class IAMovement : MonoBehaviour
{
        public float speed;

        public void Move(Vector3 direction)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        
    }