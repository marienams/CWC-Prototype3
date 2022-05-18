using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator playerJump;

    private Rigidbody PlayerRb;
    public float jump;
    public float gravityModifier;
    private bool isOnGround = false;
    public bool gameOver;
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        playerJump = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            PlayerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
            playerJump.SetTrigger("Jump_trig");

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log(isOnGround);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerJump.SetBool("Death_b", true);
            playerJump.SetInteger("DeathType_int", 1);
        }
    }
}
