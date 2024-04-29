using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 32f;
    private float jumpingPower = 40f;
    private bool isFacingRight = true, OnAir = false;
    private bool jumped = false;
    private bool falling = false;
    public StartGame StartGame;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator jussi;

    void Update()
    {
        if (StartGame.HasGameStarted())
        {

            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && OnAir == false)
            {
                Jump();
            }

            if (OnAir && Input.GetKey(KeyCode.Space) && jumped == false && rb.velocity.y <= 0 && !falling)
            {
                //Debug.Log("HYPPY");
                Jump();
            }

            if (Input.GetKey(KeyCode.DownArrow) && OnAir == false)
            {

            }


            /* _____kusee hyppykorkeuden______

            if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            */

            Flip();
        }
    }

    private void Jump()
    {
        jumped = true;

        OnAir = true;

        jussi.SetTrigger("Jump");

        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    private void FixedUpdate()
    {
        if (StartGame.HasGameStarted())
        {

            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            if (horizontal != 0 && !OnAir && Input.anyKey)
            {
                if (!Input.GetKey(KeyCode.Space))
                    jussi.SetTrigger("Move");
            }
            if (!OnAir && !Input.anyKey || !OnAir && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                jussi.SetTrigger("Idle");

            }
            else if (!OnAir && Input.GetKey(KeyCode.Space) && horizontal == 0)
            {
                jussi.SetTrigger("Idle");
            }
            else if (OnAir && Input.GetKey(KeyCode.Space) && horizontal != 0)
            {
                jussi.SetTrigger("Move");
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumped = false;
            Invoke("DisableOnAir", 0.1f);
            falling = false;
        }
    }

    private void fall()
    {
        falling = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Invoke("fall", 0.3f);
        OnAir = true;
    }

    private void DisableOnAir()
    {
        OnAir = false;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            DisableOnAir();
        }
    }


}