using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 dir;
    private MovementBehaviour mvb;
    
    void Start()
    {
        mvb= GetComponent<MovementBehaviour>();
    }

    public void SetDirection(Vector3 d)
    {
        dir = d;
        dir.Normalize();
    }
    
    void Update()
    {
        mvb.Move(dir);
    }
}
