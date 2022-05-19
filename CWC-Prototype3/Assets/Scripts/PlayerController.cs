using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator playerJump;

    public ParticleSystem explosion;

    public ParticleSystem dirtSplatter;

    public AudioClip JumpSound;

    public AudioClip Crash;

    private Rigidbody PlayerRb;
    private AudioSource playerAudio;
    public float jump;
    public float gravityModifier;
    private bool isOnGround = false;
    public bool gameOver;
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        playerJump = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            PlayerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
            playerJump.SetTrigger("Jump_trig");
            dirtSplatter.Stop();

            playerAudio.PlayOneShot(JumpSound, 1.0f);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log(isOnGround);
            dirtSplatter.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("Game Over");
            gameOver = true;
            playerJump.SetBool("Death_b", true);
            playerJump.SetInteger("DeathType_int", 1);
            explosion.Play();
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(Crash, 1.0f);
        }
    }
}
