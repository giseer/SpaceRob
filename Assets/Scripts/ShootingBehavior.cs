using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject player;
    
    public float delay;
    
    private float time;
    private Vector3 dir;

    [HideInInspector] public int x2;

    void Start()
    {
        time = 0;
        player = GameObject.FindObjectOfType<Player>().gameObject;
        x2 = 0;
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

        if(x2 == 1)
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
