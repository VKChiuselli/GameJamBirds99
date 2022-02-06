using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Dodo : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float jumpSpeed = 5;
    Animator myAnimator;
    Rigidbody2D myRigiBody2d;
    AudioPlayer audioPlayer;
    Paddle paddle;
    // Start is called before the first frame update
    void Start()
    {
        myRigiBody2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        //   myRigiBody2d.velocity = new Vector2(xPush, yPush);
        paddle = FindObjectOfType<Paddle>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDodo();
    }

    private void OnJump(InputValue value)
    {
        if (!myRigiBody2d.IsTouchingLayers(LayerMask.GetMask("Block")))
        {
            return;
        }
        if (value.isPressed)
        {
            myRigiBody2d.velocity += new Vector2(0f, jumpSpeed);
            audioPlayer.PlayJumpingClip();
        }
    }

    void MoveDodo()
    {
        float amountSpeed = moveInput.x * moveSpeed;
        Vector2 tandemVelocity = new Vector2(amountSpeed, myRigiBody2d.velocity.y);
        myRigiBody2d.velocity = tandemVelocity; //  new Vector2(paddle.transform.position.x, paddle.transform.position.y); 
        myAnimator.SetBool("OnRun", Mathf.Abs(myRigiBody2d.velocity.x) > Mathf.Epsilon);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

}
