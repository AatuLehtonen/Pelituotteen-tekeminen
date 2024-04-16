using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mopojonnebehavior : MonoBehaviour
{
    int force = 45;
    public bool directionLeft = true;

    // Update is called once per frame
    void Update()
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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
