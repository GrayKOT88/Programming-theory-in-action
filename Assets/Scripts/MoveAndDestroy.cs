using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MoveAndDestroy : MonoBehaviour
{
    protected PlayerController playerControllerScript;    
    private float topBound = 32f;
    private float lowerBound = -10f;
    protected float speed = 10f;
    protected virtual void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
        
    void Update()
    {
        Move();
        DestroyOutOfBounds();
    }
    protected virtual void Move() 
    {
        if (playerControllerScript.gameOver == false)
        {           
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }        
    }
    void DestroyOutOfBounds()
    {
       
        if (transform.position.x > topBound && gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
        }
        if (transform.position.x < lowerBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (playerControllerScript.gameOver == true && gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }    
}
