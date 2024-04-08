using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public StartGame SG;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SG.HasGameStarted())
        {
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

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("Testi");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
        // Alempaa tarvitaan Unity editorissa.
        UnityEditor.EditorApplication.isPlaying = false;
    }


}
