using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private int sharedHealth = 6; // Initial shared health value
    private int lives = 3; 
    private bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    public Image healthbar;
    public int health;
    // Function to apply damage to both players
    public void TakeDamage(int damage)
    {
        if (!isImmune)
        {
            sharedHealth -= damage;

            if (sharedHealth <= 0)
            {
                // Both players are dead
                lives--; 
                if (lives <= 0)
                {
                    Debug.Log("Both Players Dead");
                    // Handle game over (e.g., load game over scene)
                    SceneManager.LoadScene(6); 
                }
                else
                {
                    // Reset shared health 
                    sharedHealth = 6; 
                }
            }

            // Trigger player hit reaction (flickering)
            StartCoroutine(PlayerFlicker()); 

            // Update player health visuals (if applicable)
            // Example: Assuming each player has a health bar script
            // player1.GetComponent<PlayerHealthBar>().UpdateHealth(sharedHealth);
            // player2.GetComponent<PlayerHealthBar>().UpdateHealth(sharedHealth); 
        }
        this.health=health-damage;
        healthbar.fillAmount=this.health/3f;
        
    }

    IEnumerator PlayerFlicker()
    {
        isImmune = true;
        immunityTime = 0f;

        SpriteRenderer player1Sprite = player1.GetComponent<SpriteRenderer>();
        SpriteRenderer player2Sprite = player2.GetComponent<SpriteRenderer>();

        while (immunityTime < immunityDuration)
        {
            player1Sprite.enabled = !player1Sprite.enabled;
            player2Sprite.enabled = !player2Sprite.enabled;
            yield return new WaitForSeconds(0.1f); 
            immunityTime += 0.1f; 
        }

        player1Sprite.enabled = true;
        player2Sprite.enabled = true;
        isImmune = false;
    }
}