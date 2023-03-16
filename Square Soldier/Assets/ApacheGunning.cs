using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheGunning : MonoBehaviour
{
    private Transform target;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 40;
    private Vector3 vectorToTarget;
    private float nextFire = 3;
    bool shoot = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsPlayer();
        
        if (Time.time > nextFire)
        {
            nextFire = Time.time + Random.Range(1, 3);
            shoot = true;
        }
    }

    private void FixedUpdate()
    {
        if (shoot)
        {
            ShootProjectile();
            shoot = false;
        }
    }

    void RotateTowardsPlayer()
    {
        vectorToTarget = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, vectorToTarget);
    }
    
    void ShootProjectile()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(vectorToTarget * bulletForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}
