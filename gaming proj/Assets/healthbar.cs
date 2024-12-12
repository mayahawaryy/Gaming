using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            // Handle player death here
            Debug.Log("Player is dead!");
        }

        // Update the health bar
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}