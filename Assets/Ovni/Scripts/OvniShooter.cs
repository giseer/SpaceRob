using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OvniShooter : MonoBehaviour
{
    [SerializeField] private Ship ship;
    [SerializeField] private GameObject bulletPrefab;
    
    private float time;
    
    private float timeBetweenShots;

    private void Start()
    {
        time = 0;
    }

    void Update()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        Vector3 dir = ship.transform.position - transform.position;
        time += Time.deltaTime;
        if (time > timeBetweenShots)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponentInChildren<Bullet>().SetDirection(dir);
            time = 0;
        }
    } 
}
