using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{

    Vector2 moveInput;
    [SerializeField] float moveSpeed = 1;
    Rigidbody2D myRigiBody2d;
    private bool isDisappeared = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigiBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
    }

    private void OnJump(InputValue value) //scompare
    {
        if (value.isPressed)
        {
            gameObject.SetActive(true);
            if (isDisappeared)
            {
                gameObject.SetActive(false);
                isDisappeared = false;
            }

        }
    }


    private void MovePaddle()
    {
        float amountSpeed = moveInput.x * moveSpeed;
        Vector2 tandemVelocity = new Vector2(amountSpeed, myRigiBody2d.velocity.y);
        myRigiBody2d.velocity = tandemVelocity;
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

}
