using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 dir;
    private IAMovement mvb;
    
    void Start()
    {
        mvb= GetComponent<IAMovement>();
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
