using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointCounter : MonoBehaviour
{
    public static pointCounter instance;

    public Text pointText;
    public float alphaChangeSpeed = 1f; // Speed at which alpha changes
    public float targetAlpha = 1f; // Target alpha value (255 in normalized range)
    public int currentPoints = 0;

    private bool isChangingAlpha = false;

    // Start the alpha change process
    public void showCounter()
    {
        isChangingAlpha = true;
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pointText.text = "Points: " + currentPoints.ToString();
    }

    private void Update()
    {
        // Check if alpha change process is active
        if (isChangingAlpha)
        {
            // Get current color
            Color currentColor = pointText.color;

            // Calculate new alpha value
            float newAlpha = Mathf.MoveTowards(currentColor.a, targetAlpha, alphaChangeSpeed * Time.deltaTime);

            // Update alpha value in the color
            currentColor.a = newAlpha;

            // Apply the updated color to the text
            pointText.color = currentColor;

            // Check if the target alpha has been reached
            if (Mathf.Approximately(newAlpha, targetAlpha))
            {
                // Stop the alpha change process
                isChangingAlpha = false;
            }
        }
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
