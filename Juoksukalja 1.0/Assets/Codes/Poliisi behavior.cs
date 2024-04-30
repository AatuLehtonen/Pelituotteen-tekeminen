using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poliisibehavior : MonoBehaviour
{
    public bool directionLeft = true;

    bool chasing = false;

    bool changingDirection = false;

    bool onAir = false;

    private float speed = 15f;

    float jumpingPower = 40f;

    public bool lastDirLeft = false;

    private bool falling = false;

    Poliisispawner spawner;
    Transform player;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator poliisi;

    void Start()
    {
        spawner = GameObject.Find("Poliisi spawner").GetComponent<Poliisispawner>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing)
        {
            // Tarkastetaan joka sekunti jahdatessa, että täytyykö poliisin suuntaa muuttaa
            if (!changingDirection)
            {
                Invoke("changeX", 0.3f);
                changingDirection = true;
            }

            // Jos pelaaja on poliisin vasemmalla
            if (directionLeft)
            {
                rb.velocity = new Vector2(-1 * speed * 1.5f, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(1 * speed * 1.5f, rb.velocity.y);
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
            }
            else
            {
                rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
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
            Invoke("stopchansing", 20.0f);
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

        onAir = true;

        poliisi.SetTrigger("Jump");

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
            poliisi.SetTrigger("Run");
            CancelInvoke("DisableOnAir");
            Invoke("DisableOnAir", 3f);
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
        Debug.Log("disable on air");
        onAir = false;
        falling = false;
    }

    private void OnBecameInvisible()
    {
        spawner.poliiseja--;
        Destroy(gameObject);
    }
}
