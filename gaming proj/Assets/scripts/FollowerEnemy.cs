using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : EnemyController
{
    private Move_Hatem player;
    public Collider2D detectionZone;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Move_Hatem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionZone.IsTouching(player.GetComponent<Collider2D>()))
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(2);
        }
    }
}