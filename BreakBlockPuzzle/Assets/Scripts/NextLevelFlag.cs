using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelFlag : MonoBehaviour
{
    // public GameObject completedLevel;
    new Rigidbody2D rigidbody2D;
    [SerializeField] GameObject caricone;
    [SerializeField] GameObject dodo;
    [SerializeField] GameObject ball;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void CompleteLevel()
    {
        caricone.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (rigidbody2D.IsTouchingLayers(LayerMask.GetMask("Dodo")))
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                DestroyObject(dodo);
                DestroyObject(ball);
                    SceneManager.LoadScene(6);
            }
            else
            {
                DestroyObject(dodo);
                DestroyObject(ball);
                CompleteLevel();
                //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }
    }
}
