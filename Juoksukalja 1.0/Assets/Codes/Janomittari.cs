using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Janomittari : MonoBehaviour
{
    // Reference to the StartGame script
    public StartGame SG;

    // Reference to the playerHp script
    public playerHp HP;

    // Reference to the GameObject representing the thirst meter
    public GameObject janoMittari;

    // Reference to the Image component representing the thirst meter's visual
    public Image Jano;

    void Update()
    {
        // Check if the game has started
        if (SG.HasGameStarted())
        {
            // Activate the thirst meter GameObject
            janoMittari.SetActive(true);

            // Decrease the fill amount of the thirst meter gradually
            Jano.fillAmount = Mathf.Lerp(Jano.fillAmount, Jano.fillAmount - (0.016f * 3.8f), Time.deltaTime);

            // If the thirst meter is empty and the player is not invincible, apply damage to the player
            if (Jano.fillAmount <= 0 && !HP.nodamage)
            {
                Debug.Log("Mittari tyhjä!"); // Log a message indicating the meter is empty
                HP.takeDamage(); // Call the takeDamage method in the playerHp script to apply damage
                Jano.fillAmount = 1; // Reset the fill amount of the thirst meter to full
            }
        }
    }

    // Method to increase the fill amount of the thirst meter (used when drinking)
    public void Drink()
    {
        Jano.fillAmount = Jano.fillAmount + 0.33f; // Increase the fill amount by 0.33 (assuming the maximum is 1)
    }
}