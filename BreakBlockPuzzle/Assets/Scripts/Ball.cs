using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
 //   [SerializeField] float xPush = 2f;
 //   [SerializeField] float yPush = 15f;
  [SerializeField] float velocityX = 0;
  [SerializeField] float velocityY = 0;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //   rigidbody2D.velocity = new Vector2(xPush, yPush);
        rigidbody2D.AddForce(Vector2.up * 400);

    }
    void Update()
    {
        velocityX = rigidbody2D.velocity.x;
        velocityY = rigidbody2D.velocity.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rigidbody2D.IsTouchingLayers(LayerMask.GetMask("Block")))
        {
            Destroy(collision.gameObject);
        }
        if (rigidbody2D.IsTouchingLayers(LayerMask.GetMask("Dodo")))
        {
            //RESTARTR SCENA
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

}
