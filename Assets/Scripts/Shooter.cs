using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField] private Transform shootingPoint;

    [HideInInspector] public bool doubleShootActivated;

    [SerializeField] private float fireRate;

    private bool canShoot = true;

    private float remainingTimeToFire;


    private void Start()
    {
        remainingTimeToFire = fireRate;
        doubleShootActivated = false;
    }

    private void Update()
    {
        if (!canShoot)
        {
            if (remainingTimeToFire <= 0)
            {
                remainingTimeToFire = fireRate;
                canShoot = true;
            }

            remainingTimeToFire -= Time.deltaTime;
        }
    }

    private void SegundoDisparo()
    {
        var bullet2 = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        bullet2.GetComponent<Bullet>().SetDirection(transform.up);
    }

    public void Shoot()
    {
        if (canShoot)
        {
            var bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDirection(transform.up);

            Destroy(bullet, 3f);

            if (doubleShootActivated) Invoke("SegundoDisparo", 0.2f);

            canShoot = false;
        }
    }
}