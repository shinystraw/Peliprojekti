using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 movementDirection;
    float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerInput();
    }
    void Update()
    {
        Move();
    }

    void PlayerInput()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), rb.position.y);
    }

    void Move()
    {
        rb.velocity = movementDirection * speed;
    }
}