using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    public void Start()
    {
        gameOverPanel.SetActive(true);

        if (GameManager.Instance)
        {
            scoreText.text = "Final Score: " + GameManager.Instance.score.ToString();
        }
    }

    public void RestartGame()
    {
        GameManager.Instance.QuitToMenu();
    }
}
