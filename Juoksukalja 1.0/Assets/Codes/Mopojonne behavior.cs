using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mopojonnebehavior : MonoBehaviour
{
    // The force of movement
    int force = 45;

    // Boolean to determine the movement direction
    public bool directionLeft = true;

    // Update is called once per frame
    void Update()
    {
        // Move the object based on the directionLeft variable
        if (!directionLeft)
        {
            // Move to the right
            transform.position = transform.position + (Vector3.right * force) * Time.deltaTime;
        }
        else
        {
            // Move to the left
            transform.position = transform.position + (Vector3.left * force) * Time.deltaTime;
        }
    }

    // Destroy the object when it becomes invisible
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}