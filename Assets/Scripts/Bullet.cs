using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 dir;
    private MovementBehaviour mvb;
    // Start is called before the first frame update
    void Start()
    {
        mvb= GetComponent<MovementBehaviour>();
    }

    public void SetDirection(Vector3 d)
    {
        dir = d;
        dir.Normalize();
    }
    // Update is called once per frame
    void Update()
    {
        mvb.Move(dir);
    }
}
