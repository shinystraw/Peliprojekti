using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject muzzleFlashPrefab;
    private float nextFire;
    public float bulletForce = 250f;
    bool attackMode = false;
    bool shoot = false;
    int magazineSize = 6;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire && attackMode)
        {
            nextFire = Time.time + Random.Range(2,5);
            shoot = true;
            magazineSize--;
        }

    }

    private void FixedUpdate()
    {
        if (shoot)
        {
            animator.SetTrigger("Shoot");
            ShootProjectile();
            shoot = false;
        }
    }

    void ShootProjectile()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    public void AttackMode(bool toggle) 
    {
        attackMode = toggle;
        animator.SetBool("OnGround", toggle);
        nextFire = Time.time + 2f;
    }
}
