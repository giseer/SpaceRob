using UnityEngine;
using UnityEngine.Serialization;

public class BoostSpawner : MonoBehaviour
{
    public GameObject SegundoDisparoPrefab;
    public GameObject MasFrecuenciaPrefab;
    public GameObject InvulnerabilidadPrefab;

    private GameObject currentSpawnedBoost;
    
    private bool isBoostSpawned;
    
    // Timers Values
    [SerializeField] private int timeToSpawn;
    [SerializeField] private float timeToCollectBoost;
    
    private float remainingTimeToSpawn;
    private float remainingTimeToCollectBoost;
    
    private int randInd;
    private Camera mainCamera;


    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        remainingTimeToSpawn = timeToSpawn;
        remainingTimeToCollectBoost = timeToCollectBoost;
        isBoostSpawned = false;
    }

    private void Update()
    {
        SpawnTimer();
        
        if (isBoostSpawned)
        {
            CollectTimer();    
        }
    }
    
    private void SpawnTimer()
    {
        remainingTimeToSpawn -= Time.deltaTime;
        
        if (remainingTimeToSpawn <= 0)
        {
            remainingTimeToSpawn = timeToSpawn;

            isBoostSpawned = true;
            
            randInd = Random.Range(0, 3);
            
            switch(randInd)
            {
                case 0:
                    currentSpawnedBoost = Instantiate(SegundoDisparoPrefab, DesireRandomPosition(), Quaternion.identity);
                    break;

                case 1:
                    currentSpawnedBoost = Instantiate(MasFrecuenciaPrefab, DesireRandomPosition(), Quaternion.identity);
                    break;

                case 2:
                    currentSpawnedBoost = Instantiate(InvulnerabilidadPrefab, DesireRandomPosition(), Quaternion.identity);
                    break;
            }
        }
    }

    private Vector3 DesireRandomPosition()
    {
        float posX = Random.Range(0.1f, 0.9f);
        float posY = Random.Range(0.1f, 0.9f);
        
        Vector3 randomPosition = mainCamera.ViewportToWorldPoint(new Vector3(posX, posY, mainCamera.nearClipPlane));
        randomPosition.z = 0;
        
        return randomPosition;
    }

    private void CollectTimer()
    {
        remainingTimeToCollectBoost -= Time.deltaTime;
        
        if (remainingTimeToCollectBoost <= 0 && !currentSpawnedBoost.GetComponentInChildren<Boost>().boostActivated)
        {
            isBoostSpawned = false;
            Destroy(currentSpawnedBoost.gameObject);

            remainingTimeToCollectBoost = timeToCollectBoost;
        }
    }

    public void ResetBoostSpawner()
    {
        isBoostSpawned = false;
    }
}
