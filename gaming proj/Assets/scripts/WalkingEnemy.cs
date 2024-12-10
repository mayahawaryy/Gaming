using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (this.isFacingRight == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = 
            new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else 
        {
            this.GetComponent<Rigidbody2D>().velocity = 
            new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Flip();
        }
        if (other.tag == "Enemy")
        {
            Flip();
        }
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
