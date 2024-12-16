using UnityEngine;

public class Boss_Bullet : MonoBehaviour
{
    public int damage = 2; 
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            PlayerStats playerStats = FindObjectOfType<PlayerStats>(); 
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage); 
            }
            Destroy(gameObject); // Destroy the bullet after hitting a player
        }
    }

    public void SetFacingDirection(bool facingRight) 
    {
        isFacingRight = facingRight;
        spriteRenderer.flipX = !isFacingRight; 
    }
}