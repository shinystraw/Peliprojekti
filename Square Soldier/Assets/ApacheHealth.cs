using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheHealth : MonoBehaviour
{
    // Start is called before the first frame update
    int maxHealth = 300;
    int currentHealth;
    Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            animator.SetTrigger("Destroyed");
        }
    }
}
