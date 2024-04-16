using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlicker : MonoBehaviour
{
    public SpriteRenderer sprite;
    public int flickerAmount;
    public float flickerDuration;

    public void Flicker()
    {
            StartCoroutine(StartFlicker());
    }

    IEnumerator StartFlicker()
    {
        Debug.Log("Flicker");
        for (int i = 0; i < flickerAmount; i++)
        {
            sprite.color = new Color(1f, 1f, 1f, .5f);
            yield return new WaitForSeconds(flickerDuration);
            sprite.color = Color.white;
            yield return new WaitForSeconds(flickerDuration);
        }
    }
}