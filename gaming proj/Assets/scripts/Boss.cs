using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float moveSpeed = 3f;
    public float attackRange = 5f;
    public float shootInterval = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int health = 15;

    private float nextShootTime;
    private bool isFacingRight = true;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1"); 
        player2 = GameObject.FindGameObjectWithTag("Player2"); 
        nextShootTime = Time.time + shootInterval;
    }

    void Update()
    {
        // Calculate distance to player
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.transform.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.transform.position);
        float closestPlayerDistance = Mathf.Min(distanceToPlayer1, distanceToPlayer2); 

        // Move towards the closest player
        if (closestPlayerDistance > attackRange)
        {
            // Determine which player is closer
            GameObject closestPlayer = distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;

            // Flip the boss if needed
            if (closestPlayer.transform.position.x > transform.position.x && !isFacingRight)
            {
                Flip();
            }
            else if (closestPlayer.transform.position.x < transform.position.x && isFacingRight)
            {
                Flip();
            }

            transform.position = Vector2.MoveTowards(transform.position, closestPlayer.transform.position, moveSpeed * Time.deltaTime);
        }

        // Shoot bullets at player
        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootInterval;
        }
    }

    void Shoot()
    {
        // Instantiate a bullet prefab at the fire point's position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Determine bullet direction
        GameObject closestPlayer = GetClosestPlayer();
        Vector2 direction = (closestPlayer.transform.position - firePoint.position).normalized; 
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f; 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Handle boss death here (e.g., play death animation, destroy the boss)
            Destroy(gameObject);
        }
        else
        {
            // Teleport to opposite side of the current closest player
            GameObject closestPlayer = GetClosestPlayer();
            Vector3 newPosition = closestPlayer == player1 ? player2.transform.position : player1.transform.position; 

            // Adjust for consistent distance 
            float distanceToClosestPlayer = Vector2.Distance(transform.position, closestPlayer.transform.position);
            newPosition = newPosition + (newPosition - closestPlayer.transform.position).normalized * distanceToClosestPlayer; 

            transform.position = newPosition;
            Flip(); 
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    GameObject GetClosestPlayer()
    {
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.transform.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.transform.position);

        return distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;
    }
}