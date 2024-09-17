using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    public GameObject SegundoDisparoPrefab;
    public GameObject MasFrecuenciaPrefab;
    public GameObject InvulnerabilidadPrefab;
    
    public int delay;
    
    private int randInd;
    private float time;

    private void Start()
    {
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > delay)
        {
            randInd = Random.Range(0, 3);

            switch(randInd)
            {
                case 0:
                    GameObject SegundoDisparo = Instantiate(SegundoDisparoPrefab, transform.position, Quaternion.identity);
                    Destroy(SegundoDisparo, 5f);
                    break;

                case 1:
                    GameObject MasFrecuencia = Instantiate(MasFrecuenciaPrefab, transform.position, Quaternion.identity);
                    Destroy(MasFrecuencia, 5f);
                    break;

                case 2:
                    GameObject Invulnerabilidad = Instantiate(InvulnerabilidadPrefab, transform.position, Quaternion.identity);
                    Destroy(Invulnerabilidad, 5f);
                    break;
            }
            time = 0; 
        }
    }
}
