using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlicker : MonoBehaviour
{
    // Reference to the SpriteRenderer component
    public SpriteRenderer sprite;

    // Number of times to flicker the sprite
    public int flickerAmount;

    // Duration of each flicker
    public float flickerDuration;

    // Method to initiate the flickering effect
    public void Flicker()
    {
        // Start the coroutine for flickering
        StartCoroutine(StartFlicker());
    }

    // Coroutine to handle the flickering effect
    IEnumerator StartFlicker()
    {
        // Loop through the flickerAmount
        for (int i = 0; i < flickerAmount; i++)
        {
            // Set the sprite's color to semi-transparent white
            sprite.color = new Color(1f, 1f, 1f, .5f);

            // Wait for the specified flickerDuration
            yield return new WaitForSeconds(flickerDuration);

            // Set the sprite's color back to normal (white)
            sprite.color = Color.white;

            // Wait for the specified flickerDuration before the next flicker
            yield return new WaitForSeconds(flickerDuration);
        }
    }
}