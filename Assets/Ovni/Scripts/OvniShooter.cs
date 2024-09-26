using UnityEngine;

public class OvniShooter : MonoBehaviour
{
    [Header("Target Values")]
    [SerializeField] private Ship ship;
    
    [Header("Ammo Values")]
    [SerializeField] private GameObject bulletPrefab;
    
    [Header("Timer Values")]
    [SerializeField] private float fireRate;
    private float remainingTimeToShoot;
    
    private void Start()
    {
        ship = FindObjectOfType<Ship>();
        remainingTimeToShoot = fireRate;
    }

    void Update()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        Vector3 dir = ship.transform.position - transform.position;
        remainingTimeToShoot -= Time.deltaTime;
        if (remainingTimeToShoot <= 0)
        {
            remainingTimeToShoot = fireRate;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponentInChildren<Bullet>().SetDirection(dir);
        }
    } 
}
