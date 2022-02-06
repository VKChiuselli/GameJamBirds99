using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallCollider : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(Vector2.up * 400);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rigidbody2D.IsTouchingLayers(LayerMask.GetMask("Dodo")))
        {
            //RESTARTR SCENA
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
