using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poliisibehavior : MonoBehaviour
{
    int force = 15;
    public bool directionLeft = true;

    bool chasing = false;

    bool changingDirection = false;

    public bool lastDirLeft = false;

    Poliisispawner spawner;


    Transform player;
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
                Invoke("changeX", 0.5f);
                changingDirection = true;
            }

            // Jos pelaaja on poliisin vasemmalla
            if (directionLeft)
            {
                transform.position = transform.position + (Vector3.left * force * 1.5f) * Time.deltaTime;
            }
            else
            {
                transform.position = transform.position + (Vector3.right * force * 1.5f) * Time.deltaTime;
            }

        }
        else
        {
            if (!directionLeft)
            {
                transform.position = transform.position + (Vector3.right * force) * Time.deltaTime;
            }
            else
            {
                transform.position = transform.position + (Vector3.left * force) * Time.deltaTime;
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

    void stopchansing()
    {
        chasing = false;
    }

    private void OnBecameInvisible()
    {
        spawner.poliiseja--;
        Destroy(gameObject);
    }
}
