using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janomittari : MonoBehaviour
{
    public StartGame SG;

    public GameObject janoMittari;

    void Update()
    {

        if (SG.HasGameStarted())
        {
            janoMittari.SetActive(true);


        }

    }
}
