using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Unfreeze game time just in case it was frozen
        Time.timeScale = 1f;

        GameManager.Instance.LoadNextScene();
    }

    // This method will close the game (if built)
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
