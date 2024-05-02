using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    // The value of the collectible
    public int value;

    // Reference to the Janomittari script
    Janomittari jano;

    // Start is called before the first frame update
    private void Start()
    {
        // Find and assign the JanoCanvas object's Janomittari component
        jano = GameObject.Find("JanoCanvas").GetComponent<Janomittari>();
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is tagged as "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy the collectible gameObject
            Destroy(gameObject);

            // Increase points using the pointCounter singleton instance
            pointCounter.instance.IncreasePoints(value);

            // Call the Drink method in the Janomittari script
            jano.Drink();
        }
    }

    // OnBecameInvisible is called when the renderer is no longer visible by any camera
    void OnBecameInvisible()
    {
        // Destroy the collectible gameObject
        Destroy(gameObject);
    }
}