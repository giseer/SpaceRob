using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedRotation;
    private NewControls nc;    
    private MovementBehaviour mvb;

    private void OnEnable()
    {
        Vector3 postrans = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        postrans.z = 0;
        transform.position = postrans;
    }

    public void Start()
    {
        nc = GetComponent<NewControls>();
        mvb = GetComponent<MovementBehaviour>();
    }
    
    void Update()
    {
        transform.Rotate(0, 0, nc.moveValue.x * -speedRotation);
        mvb.Move(nc.moveValue.y * transform.up);
    }
}
