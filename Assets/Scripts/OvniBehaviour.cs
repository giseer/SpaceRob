using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvniBehaviour : MonoBehaviour
{
    public GameObject spawner1;
    public GameObject spawner2;
    public float tiempoMinimo = 1f;
    public float tiempoMaximo = 5f;
    public int numSpawner;

    private GameObject spawnerActivo;
    private float tiempoTranscurrido;
    private float tiempoEspera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= tiempoEspera)
        {

            if (Random.Range(0, 2) == 0)
            {
                spawnerActivo = spawner1;
                numSpawner = 1;
            }
            else
            {
                spawnerActivo = spawner2;
                numSpawner = 2;
            }

            tiempoTranscurrido = 0f;
            tiempoEspera = Random.Range(tiempoMinimo, tiempoMaximo);
            spawner1.SetActive(spawnerActivo == spawner1);
            spawner2.SetActive(spawnerActivo == spawner2);
        }
        
    }
}
