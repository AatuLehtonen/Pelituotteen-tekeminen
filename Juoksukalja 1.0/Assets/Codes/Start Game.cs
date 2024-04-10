using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public pointCounter PointCounter;
    public bool GameStarted = false;
    public bool HasGameStarted()
    {
        return GameStarted;
    }

    public void StartTheGame()
    {
        GameStarted = true;
        Destroy(gameObject);
        PointCounter.showCounter();
    }
}

