using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayer;
    Animator animator;
    float nextAttack;
    float AttackRate = 0.5f;

    // need to add jumping checker
    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //Returns if player is jumping or crouching
        if (!animator.GetBool("IsJumping") && !animator.GetBool("IsCrouching"))
        {
            if (Input.GetButtonDown("Fire2") && Time.time > nextAttack)
            {
                Attack();
                nextAttack = Time.time + AttackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitBox = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitBox)
        {
            Health health = enemy.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(100);
            }
        }

    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
