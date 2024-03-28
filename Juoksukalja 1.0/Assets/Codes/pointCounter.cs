using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointCounter : MonoBehaviour
{
    public static pointCounter instance;

    public TMP_Text pointText;
    public int currentPoints = 0;

    void Awake() {
        instance= this;
    }

    void Start()
    {
        pointText.text = "Points: " + currentPoints.ToString();
    }

    public void IncreasePoints(int v){
        currentPoints += v;
        pointText.text = "Points: " + currentPoints.ToString();

        if (currentPoints == 69){
            pointText.text = "Points: " + currentPoints.ToString() + " Nice!";
        }
    }
}
