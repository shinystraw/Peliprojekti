using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    int maxHealth = 100;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        int currentHealth = maxHealth;
        spriteRenderer= GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = Color.red;
    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;

        if(maxHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
