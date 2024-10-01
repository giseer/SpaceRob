using UnityEngine;

public class AsteroidSpawnerBehaviour : MonoBehaviour
{
    public GameObject spawner1;
    public GameObject spawner2;
    public float tiempoMinimo = 1f;
    public float tiempoMaximo = 5f;
    public int numSpawner;

    private GameObject spawnerActivo;
    private float tiempoEspera;

    private float tiempoTranscurrido;

    // Start is called before the first frame update
    private void Start()
    {
        if (Random.Range(0, 2) == 0)
            spawnerActivo = spawner1;
        else
            spawnerActivo = spawner2;
    }

    // Update is called once per frame
    private void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= tiempoEspera)
        {
            // Cambia el objeto activo al azar
            if (spawnerActivo == spawner1)
            {
                spawnerActivo = spawner2;
                numSpawner = 2;
            }
            else
            {
                spawnerActivo = spawner1;
                numSpawner = 1;
            }

            tiempoTranscurrido = 0f;
            tiempoEspera = Random.Range(tiempoMinimo, tiempoMaximo);
            spawner1.SetActive(spawnerActivo == spawner1);
            spawner2.SetActive(spawnerActivo == spawner2);
        }
    }
}