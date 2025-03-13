using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject HUDPanel;

    // Start is called before the first frame update
    public void Start()
    {
        HUDPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        HandleScore();
    }

    void HandleScore()
    {
        if (GameManager.Instance)
        {
            scoreText.text = "Score: " + GameManager.Instance.currentScore.ToString();
        }
    }
}
