using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    int maxHealth = 100;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        int currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;

        if (maxHealth == 0)
        {
            animator.SetBool("Death", true);
            // movement disable
        }
    }
}
