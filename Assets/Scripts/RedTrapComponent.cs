using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrapComponent : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private ParticleSystem hitParticles;
    private AudioSource audioSource;

    // Checks to see if Player touches the trap
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the colliding object
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            DamagePlayer();
        }
    }

    public void DamagePlayer()
    {
        if (playerHealth != null)
        {
            Debug.Log("ouch");
            playerHealth.TakeDamage(1);
        }
    }
}
