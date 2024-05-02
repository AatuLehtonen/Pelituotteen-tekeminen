using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mopojonne_spawner : MonoBehaviour
{
    // Array of spawn points where enemies will appear
    public GameObject[] spawnpoints;

    // Prefab of the enemy to spawn
    public GameObject prefab;

    // Determines whether spawning should start
    public bool startSpawning;

    // Delay between spawns
    public float spawnDelay;

    private float _currentSpawnDelay;

    // Reference to the point counter
    public pointCounter PointCounter;

    // Last spawn point
    private int spawnslot = 0;

    // Reference to the StartGame script
    public StartGame StartGame;

    // Last spawn slot used
    private int lastspawn = 0;

    // Number of enemies spawned in the current wave
    public int Jonneja = 0;

    // Size of each wave
    public int Wavesize = 5;

    private void Start()
    {
        _currentSpawnDelay = spawnDelay;
    }

    private void Update()
    {
        // Check if the game has started
        if (StartGame.HasGameStarted())
        {
            // Check if the player has enough points to start spawning enemies
            if (PointCounter.currentPoints >= 10)
            {
                // Decrease spawn delay over time
                _currentSpawnDelay -= Time.deltaTime;
                if (_currentSpawnDelay < 0)
                {
                    // Randomly determine the type of spawn (regular or wave)
                    int spawnType = Random.Range(0, 5);
                    if (spawnType < 4) // Regular spawn
                    {
                        _currentSpawnDelay = spawnDelay;
                        // Choose a random spawn point that is different from the last one
                        while (lastspawn == spawnslot)
                        {
                            spawnslot = Random.Range(0, spawnpoints.Length);
                        }
                        lastspawn = spawnslot;
                        // Instantiate the enemy at the chosen spawn point
                        GameObject Jonne = Instantiate(prefab, spawnpoints[spawnslot].transform.position, transform.rotation);
                        // Flip the sprite if spawned from the second spawn point
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
                    else // Wave spawn
                    {
                        if (PointCounter.currentPoints >= 30)
                        {
                            // Start spawning a wave of enemies
                            InvokeRepeating("Jonnewave", 0, 0.3f);
                        }
                    }
                }
            }
        }
    }

    // Method to spawn a wave of enemies
    void Jonnewave()
    {
        _currentSpawnDelay = spawnDelay;
        // Check if the number of enemies spawned in the wave is less than the wave size
        if (Jonneja < Wavesize)
        {
            // Instantiate an enemy at the spawn point
            GameObject Jonne = Instantiate(prefab, spawnpoints[spawnslot].transform.position, transform.rotation);
            // Flip the sprite if spawned from the second spawn point
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
            print("LOPETETAAN JONNE WAVE"); // Print a message indicating the end of the wave
            Jonneja = 0; // Reset the number of enemies spawned in the wave
            CancelInvoke("Jonnewave"); // Stop spawning the wave
        }
    }
}