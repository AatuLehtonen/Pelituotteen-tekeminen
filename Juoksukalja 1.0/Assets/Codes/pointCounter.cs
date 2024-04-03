using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pointCounter : MonoBehaviour
{
    public static pointCounter instance;

    public TMP_Text pointText;
    public Color color;
    public int currentPoints = 0;

    public void showCounter()
    {
        Debug.Log("päästiin tänne");
        pointText.enableVertexGradient = false;
        pointText.colorGradient = new VertexGradient(Color.white);
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pointText.text = "Points: " + currentPoints.ToString();
    }

    public void IncreasePoints(int v)
    {
        currentPoints += v;
        pointText.text = "Points: " + currentPoints.ToString();

        if (currentPoints == 69)
        {
            pointText.text = "Points: " + currentPoints.ToString() + " Nice!";
        }
    }
}
