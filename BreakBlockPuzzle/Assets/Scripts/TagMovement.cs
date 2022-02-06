using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TagMovement : MonoBehaviour
{

    Vector2 moveInput;
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float jumpSpeed = 1;
    Rigidbody2D myRigiBody2d;
    Animator myAnimator;
    private bool isDisappeared = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigiBody2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //   MoveBoth();
        MoveDodo();
        MovePaddle();
    }

    private void OnJump(InputValue value)
    {

        if (gameObject.layer == 7)
        {
            if (!myRigiBody2d.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            if (value.isPressed)
            {
                //     audioPlayer.PlayJumpingClip();
                myRigiBody2d.velocity += new Vector2(0f, jumpSpeed);
            }


        }
        if (gameObject.layer == 8)
        {

            if (value.isPressed)
            {
                if (isDisappeared)
                {

                }
            }
        }


    }

    private void MoveDodo()
    {
        //  if (gameObject.layer !=7){}
        if (gameObject.layer == 7)
        {
            float amountSpeed = moveInput.x * moveSpeed;
            Vector2 tandemVelocity = new Vector2(amountSpeed, myRigiBody2d.velocity.y);
            myRigiBody2d.velocity = tandemVelocity;
            myAnimator.SetBool("OnRun", Mathf.Abs(myRigiBody2d.velocity.x) > Mathf.Epsilon);
        }

    }
    private void MovePaddle()
    {
        //  if (gameObject.layer !=7){}
        if (gameObject.layer == 8)
        {
            float amountSpeed = moveInput.x * moveSpeed;
            Vector2 tandemVelocity = new Vector2(amountSpeed, myRigiBody2d.velocity.y);
            myRigiBody2d.velocity = tandemVelocity;
            //      myAnimator.SetBool("OnRun", Mathf.Abs(myRigiBody2d.velocity.x) > Mathf.Epsilon);
        }

    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

}
