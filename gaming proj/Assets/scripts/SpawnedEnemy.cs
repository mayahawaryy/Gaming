using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedEnemy : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<LevelManager>().RespawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
