using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller controller;

    [SerializeField] float moveForward = 1f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float boostSpeed = 1f;
    [SerializeField] float reverseSpeed = 1f;
    [SerializeField] float increaseJump = 1f;
    [SerializeField] float decreaseJump = 1f;
    [SerializeField] AudioClip jumpSFX;

    Rigidbody2D jump;
    public bool canJump;
    Rigidbody2D move;

    void Awake()
    {
        controller = this;
        jump = GetComponent<Rigidbody2D>();
        move = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Moving();
        Jumping();
    }

    void Moving()
    {
        move.velocity = new Vector3(moveForward, move.velocity.y);
    }

    public void Jumping()
    {
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            jump.velocity = Vector3.up * jumpForce;
            canJump = false;
            GetComponent<AudioSource>().PlayOneShot(jumpSFX);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Speed")
        {
            moveForward += boostSpeed;
            jumpForce += increaseJump;
        }

        if (collision.tag == "Slow")
        {
            moveForward -= reverseSpeed;
            jumpForce -= decreaseJump;
        }
    }
}
