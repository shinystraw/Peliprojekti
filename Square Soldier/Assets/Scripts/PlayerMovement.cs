using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Code used from brakeys 2d movement video tutorial 
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float runSpeed;
    [SerializeField] private Animator animator;


    private float horizontalInput;

    bool jump;
    bool crouch;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * runSpeed;

         animator.SetFloat("speed", Mathf.Abs(horizontalInput));

        
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            Debug.Log("Yes");
        }

        if (Input.GetButton("Crouch"))
        {
            crouch = true;
        } else
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        Debug.Log("works");
    }

    public void WhileCrouching(bool crouching)
    {
        animator.SetBool("IsCrouching", crouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalInput * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
