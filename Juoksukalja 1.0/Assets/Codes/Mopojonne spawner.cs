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

    public int Jonneja = 0;

    public int Wavesize = 5;

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
                    int spawnType = Random.Range(0, 5);
                    if (spawnType < 4)
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
                    else // random range = 1
                    {
                        if (PointCounter.currentPoints >= 1)
                        {
                            InvokeRepeating("Jonnewave", 0, 0.3f);
                        }

                    }

                }

            }

        }
    }
    void Jonnewave()
    {
        _currentSpawnDelay = spawnDelay;
        if (Jonneja < Wavesize)
        {
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
            Jonneja++;
        }
        else
        {
            print("LOPETETAAN JONNE WAVE");
            Jonneja = 0;
            CancelInvoke("Jonnewave");
        }
    }

}
