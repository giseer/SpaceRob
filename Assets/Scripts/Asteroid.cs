using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector3 dir;
    private IAMovement mvb;
    // Start is called before the first frame update

    private void Start()
    {
        mvb = GetComponent<IAMovement>();
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


