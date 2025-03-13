using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    public void Start()
    {
        gameOverPanel.SetActive(true);

        if (GameManager.Instance)
        {
            scoreText.text = "Final Score: " + GameManager.Instance.score.ToString();
            timerText.text =
                "Final Time: "
                + GameManager.Instance.currentHours
                + "h:"
                + GameManager.Instance.currentMinutes
                + "m:"
                + (int)GameManager.Instance.currentSeconds
                + "s";
        }
    }

    public void RestartGame()
    {
        GameManager.Instance.QuitToMenu();
    }
}
