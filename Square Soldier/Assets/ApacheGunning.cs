using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheGunning : MonoBehaviour
{
    private Transform target;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject muzzleFLashPrefab;
    [SerializeField] float bulletForce = 30;
    GameObject fx; 
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
        if(fx != null)
        {
            fx.transform.position = firePoint.position;
        }

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
        GameObject fx = Instantiate(muzzleFLashPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 offset = new Vector2(vectorToTarget.x + Random.Range(-2f, 2f), vectorToTarget.y);
        rb.AddForce(offset * bulletForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}
