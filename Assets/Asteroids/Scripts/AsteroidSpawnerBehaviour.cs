using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawnerBehaviour : MonoBehaviour
{
    private List<AsteroidSpawner> spawners = new List<AsteroidSpawner>();
    private int activeSpawnerIndex;
    
    [Header("Time Values")]
    public float tiempoMinimo = 1f;
    public float tiempoMaximo = 5f;
    
    private float tiempoEspera;
    private float tiempoTranscurrido;

    private void Awake()
    {
        spawners = GetComponentsInChildren<AsteroidSpawner>(true).ToList();
    }

    private void Start()
    {
        tiempoTranscurrido = tiempoEspera;
    }

    private AsteroidSpawner ChooseRandomSpawner()
    {
        int newActiveSpawnerIndex;
        
        do
        {
            newActiveSpawnerIndex = Random.Range(0, spawners.Count);    
        } while (newActiveSpawnerIndex == activeSpawnerIndex);
        
        return spawners[activeSpawnerIndex];   
    }

    private void Update()
    {
        if (tiempoTranscurrido >= tiempoEspera)
        {
            tiempoTranscurrido = 0f;
            tiempoEspera = Random.Range(tiempoMinimo, tiempoMaximo);
            
            ChooseRandomSpawner().gameObject.SetActive(true);
        }
        
        tiempoTranscurrido += Time.deltaTime;
    }
}