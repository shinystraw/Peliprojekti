using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    bool isFacingRight = true;

    [SerializeField] Transform player;
    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        LookAtPlayer();
    }


    [ContextMenu("Unload")]


    public void LookAtPlayer()
    {
        if (player.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }
        else if (player.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
