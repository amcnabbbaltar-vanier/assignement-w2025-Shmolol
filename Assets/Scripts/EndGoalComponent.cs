using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalComponent : MonoBehaviour
{
    // Checks to see if Player reaches the goal
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LoadNextScene();
        }
    }
}
