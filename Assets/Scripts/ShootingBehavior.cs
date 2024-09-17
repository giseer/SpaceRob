using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootingBehavior : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Ship player;
    
    public float delay;
    
    private float time;
    private Vector3 dir;

    [HideInInspector] public bool doubleShootActivated;

    void Start()
    {
        time = 0;
        player = FindObjectOfType<Ship>();
        doubleShootActivated = false;
    }

    void SegundoDisparo()
    {
        GameObject bullet2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet2.GetComponent<Bullet>().SetDirection(transform.up);
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(transform.up);
        
        Destroy(bullet, 3f);

        if(doubleShootActivated)
        {
            Invoke("SegundoDisparo", 0.2f);
        }
    }
    
    private void Update()
    {
        if(gameObject.layer == LayerMask.NameToLayer("Ovni"))
        {          
            dir = player.transform.position - transform.position;
            time += Time.deltaTime;
            if (time > delay)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().SetDirection(dir);
                time = 0;
            }           
            
        }
    }
}
