using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_damage : MonoBehaviour
{
    public int damage = 1;
    bool hasdamaged=false;
    void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player"&&!hasdamaged)
    {
        hasdamaged=true;
        StartCoroutine(DelayedDamage());
    }
}

IEnumerator DelayedDamage()
{
    yield return new WaitForSeconds(1f);
    FindObjectOfType<PlayerStats>().TakeDamage(damage);
}

    
}

