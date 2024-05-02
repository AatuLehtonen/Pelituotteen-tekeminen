using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; // Unity.VisualScripting is not used in this script, you might consider removing this line
using UnityEngine;

public class Hearts : MonoBehaviour
{
    // Reference to the GameObject containing the hearts
    public GameObject hearts;

    // Method to set the hearts GameObject active
    public void setactive()
    {
        // Set the hearts GameObject active
        hearts.SetActive(true);
    }
}
