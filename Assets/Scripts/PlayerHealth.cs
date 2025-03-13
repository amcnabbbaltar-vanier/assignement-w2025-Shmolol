using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static bool takeDamageOnRespawn = false;
    private static int respawnDamage = 0;
    private static int savedHealth; // Stores current health between respawns

    public int maxHealth = 3;
    private int currentHealth;
    public Slider healthBar;

    private void Start()
    {
        currentHealth = (takeDamageOnRespawn) ? savedHealth - 1 : maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        takeDamageOnRespawn = false;

        // If health is 0 or below after respawn, trigger full death instead
        if (currentHealth <= 0)
        {
            Die();
            return; // Prevents the game from running with 0 HP
        }
    }

    public static void IncrementRespawnDamage(int currentHP)
    {
        respawnDamage++; // Called before respawning to accumulate fall damage
        savedHealth = currentHP; // Store current HP before respawning
        takeDamageOnRespawn = true; // Ensures damage is applied on respawn
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        respawnDamage = 0;
        GameManager.Instance.RestartScene();
    }
}
