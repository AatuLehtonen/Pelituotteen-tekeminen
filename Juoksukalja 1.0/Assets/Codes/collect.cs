using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{

    public int value;

    Janomittari jano;

    private void Start()
    {
        jano = GameObject.Find("JanoCanvas").GetComponent<Janomittari>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            pointCounter.instance.IncreasePoints(value);

            jano.Drink();
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
