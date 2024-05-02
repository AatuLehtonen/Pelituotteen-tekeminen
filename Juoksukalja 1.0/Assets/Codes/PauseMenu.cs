using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Indicates whether the game is currently paused
    public static bool GameIsPaused = false;

    // Reference to the pause menu UI GameObject
    public GameObject pauseMenuUI;

    // Reference to the StartGame script
    public StartGame SG;

    void Update()
    {
        // Check for the Escape key input and if the game has started
        if (Input.GetKeyDown(KeyCode.Escape) && SG.HasGameStarted())
        {
            // If the game is paused, resume it; otherwise, pause it
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Method to resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Deactivate the pause menu UI
        Time.timeScale = 1f; // Set the time scale to normal to resume the game
        GameIsPaused = false; // Update the GameIsPaused flag
    }

    // Method to pause the game
    void Pause()
    {
        pauseMenuUI.SetActive(true); // Activate the pause menu UI
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game
        GameIsPaused = true; // Update the GameIsPaused flag
        Debug.Log("Testi"); // Log a test message
    }

    // Method to exit the game
    public void ExitGame()
    {
        Debug.Log("Exitting game..."); // Log a message indicating the intention to exit the game
        SceneManager.LoadScene("gamescene2"); // Load the specified scene (replace "gamescene2" with the appropriate scene name)
        Time.timeScale = 1f; // Set the time scale to normal
        GameIsPaused = false; // Update the GameIsPaused flag
    }
}