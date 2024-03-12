using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    private AudioSource playerAudio;
    private Animator playerAnim;
    private Rigidbody playerRb;
    private float jampForce = 750;
    private float gravitiMode = 2;
    public bool isOnGround = true;
    public bool gameOver = false;   
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip throwingSound;    
    private float verticallInput;
    private float speed = 5;   

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();        
        Physics.gravity *= gravitiMode;
        playerAudio = GetComponent<AudioSource>();       
    }

    void Update()
    {
        VerticaRangeMove();
        JumpMove();
        StoneThrowing();
    }
    private void StoneThrowing()
    {
        Vector3 stonePos = new Vector3(transform.position.x, (transform.position.y + 1.3f), transform.position.z);
        if (Input.GetKeyDown(KeyCode.V) && !gameOver)
        {
            Instantiate(projectilePrefab, stonePos, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(throwingSound, 1.0f);
        }
    }
   
    private void VerticaRangeMove()
    {
        if (transform.position.z < -4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4);
        }
        if (transform.position.z > 3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 3);
        }
        if (gameOver == false)
        {
            verticallInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * -verticallInput * Time.deltaTime * speed);
        }
    }
    private void JumpMove()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jampForce, ForceMode.Impulse);
            isOnGround = false;           
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);            
        }
    }
}
