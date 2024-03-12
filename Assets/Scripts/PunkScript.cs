using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkScript : MoveAndDestroy
{
    public ParticleSystem exposionParticle;
    private MainUI mainUI;
    private int pointValue = 1;
    protected override void Move()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
    private Animator playerAnim;
    protected override void Start()
    {
        base.Start();
        playerAnim = GetComponent<Animator>();
        mainUI = GameObject.Find("Canvas").GetComponent<MainUI>();
    }
    private void OnTriggerEnter(Collider other)
    {       
        Destroy(gameObject);        
        Destroy(other.gameObject);
        Instantiate(exposionParticle, transform.position, exposionParticle.transform.rotation);
        mainUI.UpdateScore(pointValue);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);            
        }
    }   
}
