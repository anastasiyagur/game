using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCharacter : MonoBehaviour
{

    [SerializeField] private HealthBar healthbar;
    [SerializeField] private float maxHealth = 100.0f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);
        healthbar.UpdateHealthBar(maxHealth, currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died.");
        ReturnToMainMenu();
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }


}
