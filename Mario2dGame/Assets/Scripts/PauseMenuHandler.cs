using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    // [SerializeField] GameObject PlayerObject;

    // Redirects the player to the home screen
    public void homeMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    // Pauses the game
    public void pauseGame()
    {
        pausePanel.SetActive(true);
        // PlayerObject.SetActive(true);
        Time.timeScale = 0f;
    }

    // Resumes the game
    public void resumeGame()
    {
        pausePanel.SetActive(false);
        // PlayerObject.SetActive(false);
        Time.timeScale = 1f;
    }

    // Restart current level
    public void restartCurrentLevel()
    {
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Settings home handler
    public void backToHome()
    {
        SceneManager.LoadScene(0);
    }
}
