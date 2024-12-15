using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private int maxSharedHealth = 4; // Store max health for easier adjustments
    private int sharedHealth;

    private int lives = 2;
    private bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    public Image healthbar;

    void Start()
    {
        // Initialize shared health at the beginning
        sharedHealth = maxSharedHealth;
        healthbar.fillAmount = 1f; // Initialize health bar to full
    }

    // Function to apply damage to both players
    public void TakeDamage(int damage)
    {
        if (!isImmune)
        {
            sharedHealth -= damage;
            healthbar.fillAmount = (float)sharedHealth / 4f;

            if (sharedHealth <= 0)
            {

                // Both players are dead
                lives--;
                FindObjectOfType<LevelManager>().RespawnPlayer();
                sharedHealth = maxSharedHealth;
                healthbar.fillAmount = (float)sharedHealth / 4f;
                if (lives <= 0)
                {
                    Debug.Log("Both Players Dead");

                    Destroy(player1);
                    Destroy(player2);
                    SceneManager.LoadScene(11);
                }

            }

            // Trigger player hit reaction (flickering)
            StartCoroutine(PlayerFlicker());
        }
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