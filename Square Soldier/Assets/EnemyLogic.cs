using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] Transform groundPos;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float detectionRange;
    private Rigidbody2D rb;
    private bool onGround = false;
    [SerializeField] float maxFallSpeed;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
            // pallo menee ilmaan
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!onGround)
        {
            CheckGround();
        }
    }

    private void FixedUpdate()
    {
        CapFallVelocity();
    }

    void CheckGround()
    {
        Collider2D groundDetector = Physics2D.OverlapCircle(groundPos.position, detectionRange, groundLayer);
        
        if(groundDetector != null)
        {
            onGround = true;
            OnLandEvent.Invoke();
            Debug.Log("is on ground");
        }
    }

    public bool ObjectOnGround()
    {
        return onGround;
    }

    private void OnDrawGizmos()
    {
        if(groundPos == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(groundPos.position, detectionRange);
    }

    public void CapFallVelocity()
    {
        // maxfallspeed nopeutus jos pallo hajoaa
        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, maxFallSpeed));
        }
    }
}
