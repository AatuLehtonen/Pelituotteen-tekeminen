using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poliisibehavior : MonoBehaviour
{
    int force = 15;
    public bool directionLeft = true;

    bool chasing = false;


    Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing)
        {
            // Jos pelaaja on poliisin vasemmalla
            if (player.position.x < transform.position.x)
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

    void stopchansing()
    {
        chasing = false;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
