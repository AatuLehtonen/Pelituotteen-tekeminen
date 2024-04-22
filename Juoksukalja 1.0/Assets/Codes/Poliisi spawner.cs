using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poliisispawner : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject prefab;
    public bool startSpawning;
    public float spawnDelay;
    private float _currentSpawnDelay;
    public pointCounter PointCounter;
    private int spawnslot = 0;
    public StartGame StartGame;
    private int lastspawn = 0;

    private void Start()
    {
        _currentSpawnDelay = spawnDelay;
    }

    private void Update()
    {

        if (StartGame.HasGameStarted())
        {
            if (PointCounter.currentPoints >= 1)
            {
                //Debug.Log(PointCounter.currentPoints);
                _currentSpawnDelay -= Time.deltaTime;
                if (_currentSpawnDelay < 0)
                {
                    _currentSpawnDelay = spawnDelay;
                    while (lastspawn == spawnslot)
                    {
                        spawnslot = Random.Range(0, spawnpoints.Length);
                    }

                    lastspawn = spawnslot;
                    GameObject poliisi = Instantiate(prefab, spawnpoints[spawnslot].transform.position, transform.rotation);
                    if (spawnslot == 1)
                    {
                        poliisi.GetComponent<SpriteRenderer>().flipX = true;
                        poliisi.GetComponent<Poliisibehavior>().directionLeft = true;
                    }
                    else
                    {
                        poliisi.GetComponent<Poliisibehavior>().directionLeft = false;
                    }

                }

            }

        }
    }
}
