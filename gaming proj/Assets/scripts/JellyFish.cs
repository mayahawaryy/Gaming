using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : EnemyController
{

public float HorizontalSpeed;
public float VerticalSpeed;
public float amplitude;
private Vector3 temp_position;
//private Controller player;


    // Start is called before the first frame update
    void Start()
    {
        //player = FindobjectofType<Controller>();
        temp_position = transform.position;  
    }

void FixedUpdate ()
{

temp_position.x += HorizontalSpeed;
temp_position.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
transform.position = temp_position;

}

void OnTriggerEnter2D(Collider2D collider)
{
if (collider.tag == "Wall")
{
Flip ();
}
else if (collider.tag == "Enemy")
{
Flip ();
}
if(collider.tag == "Player")
{
FindObjectOfType<PlayerStats>().TakeDamage(damage);
}
   
}
}