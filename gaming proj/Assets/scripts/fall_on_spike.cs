using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_on_spike : MonoBehaviour
{
    int damage =1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
