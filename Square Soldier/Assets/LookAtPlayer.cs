using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    bool isFacingRight = true;
    [SerializeField] Transform firepoint;
    Transform player;
    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        Look();
    }

    public void Look()
    {
        if (player.position.x < transform.position.x && isFacingRight)
        {
            firepoint.Rotate(0,180f,0);
            Flip();
        }
        else if (player.position.x > transform.position.x && !isFacingRight)
        {
            firepoint.Rotate(0, 180f, 0);
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