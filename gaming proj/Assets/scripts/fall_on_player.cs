using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_on_player : MonoBehaviour
{
    // Delay before the object starts to fall
    public float fallDelay = 0.2f;
        public int damage = 6;


    // Rigidbody2D of the falling object
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Ensure the Rigidbody is initially set to not simulate physics
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Trigger method for detecting the player passing underneath
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with the player (assuming the player has the "Player" tag)
        if (other.CompareTag("Player"))
        {
            Invoke("EnableGravity", fallDelay);
        }
       
    }

    // Method to enable physics and make the object fall
    void EnableGravity()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}

