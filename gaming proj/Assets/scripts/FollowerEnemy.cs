using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : EnemyController
{
    private Move player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
    }
}
