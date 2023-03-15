using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    Animator animator;
    int maxHealth = 100;
    LookAtPlayer disableLookOnDeath;
    EnemyShooting shooting;
    // Start is called before the first frame update
    void Start()
    {
        shooting= GetComponent<EnemyShooting>();
        disableLookOnDeath = GetComponent<LookAtPlayer>(); 
        int currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;

        if(maxHealth == 0)
        {
            shooting.AttackMode(false);
            disableLookOnDeath.enabled = false;
            animator.SetTrigger("Death");
            Destroy(gameObject, 1.5f);
        }
    }
}
