using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mopojonne_spawner : MonoBehaviour
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
            if (PointCounter.currentPoints == 10)
            {

                if (startSpawning)
                {
                    _currentSpawnDelay -= Time.deltaTime;
                    if (_currentSpawnDelay < 0)
                    {
                        _currentSpawnDelay = spawnDelay;
                        while (lastspawn == spawnslot)
                        {
                            spawnslot = Random.Range(0, spawnpoints.Length);
                        }

                        lastspawn = spawnslot;
                        GameObject Jonne = Instantiate(prefab, spawnpoints[spawnslot].transform.position, transform.rotation);
                        if (spawnslot == 1)
                        {
                            Jonne.GetComponent<SpriteRenderer>().flipX = true;
                            Jonne.GetComponent<Mopojonnebehavior>().directionLeft = false;
                        }
                        else
                        {
                            Jonne.GetComponent<Mopojonnebehavior>().directionLeft = true;
                        }

                    }
                }

            }
        }
    }
}
