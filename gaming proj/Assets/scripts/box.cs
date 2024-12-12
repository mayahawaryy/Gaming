using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public Animator animator; // Reference to the animator component

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the key
        if (other.CompareTag("Key"))
        {
            // Trigger the animation
            
            animator.SetTrigger("open box");
            
        }
    }
}

