using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject HUDPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    public void Start()
    {
        HUDPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        HandleScore();
        UpdateTimerUI();
    }

    //call this on update
    public void UpdateTimerUI()
    {
        //set timer UI
        GameManager.Instance.currentSeconds += Time.deltaTime;
        timerText.text =
            "Time: "
            + GameManager.Instance.currentHours
            + "h:"
            + GameManager.Instance.currentMinutes
            + "m:"
            + (int)GameManager.Instance.currentSeconds
            + "s";
        if (GameManager.Instance.currentSeconds >= 60)
        {
            GameManager.Instance.currentMinutes++;
            GameManager.Instance.currentSeconds = 0;
        }
        else if (GameManager.Instance.currentMinutes >= 60)
        {
            GameManager.Instance.currentHours++;
            GameManager.Instance.currentMinutes = 0;
        }
    }

    void HandleScore()
    {
        if (GameManager.Instance)
        {
            scoreText.text = "Score: " + GameManager.Instance.currentScore.ToString();
        }
    }
}
