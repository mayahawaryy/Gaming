using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickbox : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite brokenBlock; 

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // No need for updates in this script
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetContact(0).point.y < transform.position.y)
        {
            // Display the brokenBlock sprite permanently
            sr.sprite = brokenBlock;

            // Optionally disable collision after breaking
            GetComponent<Collider2D>().enabled = false; 
        }
    }
}