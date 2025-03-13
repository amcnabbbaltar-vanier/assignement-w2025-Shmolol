using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuPanel;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the 'ESC' key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Show Pause Menu UI
        pauseMenuPanel.SetActive(true);

        // Freeze game time
        Time.timeScale = 0f;

        isPaused = true;
    }

    // This method resumes the game
    public void ResumeGame()
    {
        // Hide Pause Menu UI
        pauseMenuPanel.SetActive(false);

        // Unfreeze game time
        Time.timeScale = 1f;

        isPaused = false;
    }

    // This method will restart the current level
    public void RestartGame()
    {
        // Ensures game time is unfrozen when level resets
        Time.timeScale = 1f;

        GameManager.Instance.RestartScene();
    }

    // This method will quit to the main menu
    public void QuitGame()
    {
        GameManager.Instance.QuitToMenu();
    }
}
