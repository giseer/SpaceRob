using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsBehaviour : MonoBehaviour
{   
    public int SegSegundoDisparo;
    public int SegMasFrecuencia;
    public int SegInvulnerabbilidad;

    private ShootingBehavior SB;
    private MovementBehaviour MB;
    private Collider2D playCollider;

    private float time;
    private float speedAnterior;

    private void Awake()
    {
        SB = GetComponent<ShootingBehavior>();
        MB = GetComponent<MovementBehaviour>();
        playCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        time = 0;
        speedAnterior = MB.speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("X2"))
        {
            SB.x2 = 1;
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Flash")) // No entiendo el PowerUp, te he aumentado la velocidad de la nave
        {
            speedAnterior = MB.speed;
            MB.speed = 5;
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Invul"))
        {
            playCollider.enabled = false;            
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    private void Update()
    {        
        Debug.Log(speedAnterior);
        Debug.Log(MB.speed);
        if(SB.x2 == 1)
        {
            time += Time.deltaTime;
            if (time > SegSegundoDisparo)
            {
                SB.x2 = 0;
                time = 0;
            }  
        }
        else if(MB.speed != speedAnterior)
        {
            time += Time.deltaTime;
            if (time > SegMasFrecuencia)
            {
                MB.speed = speedAnterior;
                time = 0;
            }              
        }
        else if(playCollider.enabled == false) 
        {
            time += Time.deltaTime;
            if (time > SegInvulnerabbilidad)
            {
                playCollider.enabled = true;
                GetComponent<Renderer>().material.color = Color.white;
                time = 0;
            }  
        }
    }
}
