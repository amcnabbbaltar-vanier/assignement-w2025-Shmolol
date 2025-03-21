using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneComponent : MonoBehaviour
{
    // Checks to see if Player touches the trap
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                PlayerHealth.IncrementRespawnDamage(playerHealth.GetCurrentHealth()); // Store current HP before restart
            }
            GameManager.Instance.RestartScene();
        }
    }
}
