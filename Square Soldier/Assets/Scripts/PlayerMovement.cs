using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Code used from brakeys 2d movement video tutorial 
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float speed;

    private float horizontalInput;
    private float verticalInput;

    bool jump;
    bool crouch;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0.01)
        {
            jump = true;
        }

        if (verticalInput < -0.01)
        {
            crouch = true;
        } else
        {
            crouch = false;
        }

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalInput * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


}
