using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int currentScore = 0;

    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    public float currentSeconds;
    public int currentMinutes;
    public int currentHours;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementScore()
    {
        currentScore += 50; // im pretty sure imma use this for the green powerup
        Debug.Log("Score: " + currentScore);
    }

    public void RestartScene()
    {
        currentScore = score;

        // currentSeconds = secondsCount;
        // currentMinutes = minuteCount;
        // currentHours = hourCount;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        score = currentScore;

        secondsCount = currentSeconds;
        minuteCount = currentMinutes;
        hourCount = currentHours;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitToMenu()
    {
        score = 0;
        currentScore = 0;
        secondsCount = 0f;
        minuteCount = 0;
        hourCount = 0;
        currentSeconds = 0f;
        currentMinutes = 0;
        currentHours = 0;

        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
