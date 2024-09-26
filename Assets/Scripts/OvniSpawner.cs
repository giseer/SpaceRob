using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OvniPoint
{
    public enum spawnDirection
    {
        Left,
        Right
    }
    
    [SerializeField] public Transform spawnPoint;
    [SerializeField] public spawnDirection direction;
}

public class OvniSpawner : MonoBehaviour
{
    [SerializeField] private Ovni OvniPrefab;
    
    [SerializeField] private List<OvniPoint> points;

    private Ovni lastOvniSpawned;
    
    private OvniPoint decidedPoint;
    
    //Timer Values

    [SerializeField] private float spawnRate;

    private float remainingTimeToSpawn;

    private void Start()
    {
        remainingTimeToSpawn = spawnRate;
    }

    private void Update()
    {
        remainingTimeToSpawn -= Time.deltaTime;
        if (remainingTimeToSpawn <= 0)
        {
            remainingTimeToSpawn = spawnRate;
            SpawnOvni();
        }
    }

    private void SpawnOvni()
    {
        lastOvniSpawned = Instantiate(OvniPrefab, DecideSpawnPointPosition(), Quaternion.identity, transform);

        if (decidedPoint.direction == OvniPoint.spawnDirection.Left)
        {
            lastOvniSpawned.dir = Vector3.left;
        }
        else if (decidedPoint.direction == OvniPoint.spawnDirection.Right)
        {
            lastOvniSpawned.dir = Vector3.right;
        }
    }

    private Vector3 DecideSpawnPointPosition()
    {
        var randomIndex = UnityEngine.Random.Range(0, points.Count);
        decidedPoint = points[randomIndex]; 
        return decidedPoint.spawnPoint.position;
    }
}