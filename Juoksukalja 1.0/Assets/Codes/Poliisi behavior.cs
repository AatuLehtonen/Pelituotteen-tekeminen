using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poliisibehavior : MonoBehaviour
{
    int force = 15;
    public bool directionLeft = true;

    bool chasing = false;

    bool changingDirection = false;

    bool onAir = false;

    bool jumped = false;

    private float speed = 15f;

    float jumpingPower = 30f;

    public bool lastDirLeft = false;

    private bool falling = false;

    Poliisispawner spawner;
    Transform player;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        spawner = GameObject.Find("Poliisi spawner").GetComponent<Poliisispawner>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing && !onAir)
        {
            // Tarkastetaan joka sekunti jahdatessa, että täytyykö poliisin suuntaa muuttaa
            if (!changingDirection)
            {
                Invoke("changeX", 0.5f);
                changingDirection = true;
            }

            // Jos pelaaja on poliisin vasemmalla
            if (directionLeft)
            {
                rb.velocity = new Vector2(-1 * speed * 1.5f, rb.velocity.y);
                //transform.position = transform.position + (Vector3.left * force * 1.5f) * Time.deltaTime;
            }
            else
            {
                rb.velocity = new Vector2(1 * speed * 1.5f, rb.velocity.y);
                //transform.position = transform.position + (Vector3.right * force * 1.5f) * Time.deltaTime;
            }

            if (player.position.y > transform.position.y && !onAir && !falling)
            {
                Jump();

            }

        }
        else
        {
            if (!directionLeft)
            {
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
                //transform.position = transform.position + (Vector3.right * force) * Time.deltaTime;
            }
            else
            {
                rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
                //transform.position = transform.position + (Vector3.left * force) * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chasing = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("stopchansing", 5.0f);
        }
    }

    void changeX()
    {

        if (player.position.x < transform.position.x)
        {
            directionLeft = true;
            if (!lastDirLeft)
            {
                transform.eulerAngles = new Vector3(180, transform.eulerAngles.y, 180);
                lastDirLeft = true;
            }
        }
        else if (player.position.x > transform.position.x)
        {

            directionLeft = false;
            if (lastDirLeft)
            {
                transform.eulerAngles = new Vector3(180, transform.eulerAngles.y, 180);
                lastDirLeft = false;
            }
        }
        changingDirection = false;
    }

    private void Jump()
    {
        if (onAir || falling) // prevent police to jump if on air
            return;

        jumped = true;

        onAir = true;

        //animator.SetTrigger("Jump");

        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    void stopchansing()
    {
        chasing = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Invoke("DisableOnAir", 0.3f);
        }
    }

    private void fall()
    {
        falling = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        fall();
        onAir = true;
    }

    private void DisableOnAir()
    {
        onAir = false;
        jumped = false;
        falling = false;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            DisableOnAir();
        }
    }

    private void OnBecameInvisible()
    {
        spawner.poliiseja--;
        Destroy(gameObject);
    }
}
